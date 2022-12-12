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
[Route("api/courses/{courseId:guid}/chapters/{chapterId:guid}/widgets")]
public class WidgetsController : ControllerBase
{
    private readonly IWidgetsService service;
    private readonly JsonOptions jsonOptions;
    private static readonly ConcurrentDictionary<WidgetTypeDto, Type> WidgetContentDtoTypes = new();

    public WidgetsController(IOptions<JsonOptions> jsonOptions, IWidgetsService service)
    {
        this.service = service;
        this.jsonOptions = jsonOptions.Value;
    }

    [HttpPost]
    public async Task<ActionResult> PostWidgetsToChapter(Guid courseId, Guid chapterId,
        [FromBody] PostWidgetDto[] widgets)
    {
        var modelWidgets = widgets.Select(widget =>
        {
            var widgetDto = (WidgetContentBaseDto)widget.Value.Deserialize(GetWidgetContentType(widget.Type),
                jsonOptions.JsonSerializerOptions)!;
            return (WidgetContent)widgetDto.Adapt(widgetDto.GetType(), widgetDto.ModelWidgetContentType)!;
        }).ToArray();

        await service.PostWidgets(courseId, chapterId, modelWidgets);
        return Ok();
    }

    private static Type GetWidgetContentType(WidgetTypeDto widgetTypeDto) =>
        WidgetContentDtoTypes.GetOrAdd(widgetTypeDto, typeDto => Assembly.GetExecutingAssembly().GetTypes()
            .Single(t => t.GetCustomAttribute<WidgetDtoTypeAttribute>()?.WidgetType == typeDto));
}