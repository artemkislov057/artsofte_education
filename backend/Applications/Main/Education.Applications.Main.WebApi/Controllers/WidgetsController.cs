using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;
using Education.Applications.Main.Model.Models.Widgets;
using Education.Applications.Main.Model.Services;
using Education.Applications.Main.WebApi.Attributes;
using Education.Applications.Main.WebApi.Dto.Widgets;
using Education.Applications.Main.WebApi.Dto.Widgets.Contents;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Education.Applications.Main.WebApi.Controllers;

[ApiController]
[Route("api/courses/{courseId:guid}/modules/{moduleId:guid}/widgets")]
public class WidgetsController : ControllerBase
{
    private readonly IWidgetsService service;
    private readonly JsonOptions jsonOptions;
    private static readonly ConcurrentDictionary<WidgetTypeDto, Type> WidgetContentDtoTypes = new();
    private static readonly ConcurrentDictionary<Type, WidgetTypeDto> WidgetContentTypesDto = new();
    private static readonly ConcurrentDictionary<Type, Type> DtoTypesByModel = new();

    public WidgetsController(IOptions<JsonOptions> jsonOptions, IWidgetsService service)
    {
        this.service = service;
        this.jsonOptions = jsonOptions.Value;
    }

    [HttpPost]
    public async Task<ActionResult> PostWidgetsToModule(Guid courseId, Guid moduleId,
        [FromBody] PostWidgetDto[] widgets)
    {
        var modelWidgets = widgets.Select(widget =>
        {
            var widgetDto = (WidgetContentBaseDto)widget.Value.Deserialize(GetWidgetContentType(widget.Type),
                jsonOptions.JsonSerializerOptions)!;
            return (WidgetContent)widgetDto.Adapt(widgetDto.GetType(), widgetDto.GetModelWidgetContentType())!;
        });

        await service.PostWidgets(courseId, moduleId, modelWidgets);
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<GetWidgetDto[]>> GetWidgetsFromModule(Guid courseId, Guid moduleId)
    {
        var widgets = await service.GetWidgets(courseId, moduleId);
        var result = widgets.Select(w =>
        {
            var modelType = w.GetType();
            var dtoType = GetDtoTypeFromModel(modelType);
            var dto = (WidgetContentBaseDto)w.Adapt(modelType, dtoType)!;
            return new GetWidgetDto(w.Id, GetWidgetTypeDto(dto), dto);
        });
        return Ok(result.ToArray());
    }

    private static Type GetWidgetContentType(WidgetTypeDto widgetTypeDto) =>
        WidgetContentDtoTypes.GetOrAdd(widgetTypeDto, typeDto => Assembly.GetExecutingAssembly().GetTypes()
            .Single(t => t.GetCustomAttribute<WidgetDtoTypeAttribute>()?.WidgetType == typeDto));

    private static WidgetTypeDto GetWidgetTypeDto(WidgetContentBaseDto dto) =>
        WidgetContentTypesDto.GetOrAdd(dto.GetType(),
            type => type.GetCustomAttribute<WidgetDtoTypeAttribute>()?.WidgetType ??
                    throw new InvalidOperationException());

    private static Type GetDtoTypeFromModel(Type modelType)
    {
        return DtoTypesByModel.GetOrAdd(modelType, modelT =>
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(WidgetContentBaseDto))
                .Where(dtoType =>
                {
                    var constructor = dtoType.GetConstructor(Array.Empty<Type>()) ??
                                      throw new InvalidOperationException();
                    var obj = constructor.Invoke(Array.Empty<object>());
                    var method = dtoType.GetMethod(nameof(WidgetContentBaseDto.GetModelWidgetContentType))!;
                    return (Type)method.Invoke(obj, Array.Empty<object>())! == modelT;
                }).Single();
        });
    }
}