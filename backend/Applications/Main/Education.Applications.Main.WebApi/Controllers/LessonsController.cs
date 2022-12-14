using System.Collections.Concurrent;
using System.Net;
using System.Reflection;
using System.Text.Json;
using Education.Applications.Common.Constants;
using Education.Applications.Main.Model.Models.Lessons;
using Education.Applications.Main.Model.Services;
using Education.Applications.Main.WebApi.Attributes;
using Education.Applications.Main.WebApi.Dto.Lessons;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents;
using Education.Applications.Main.WebApi.SwaggerExamples.Request.Lessons;
using Education.Applications.Main.WebApi.SwaggerExamples.Response.Lessons;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Filters;

namespace Education.Applications.Main.WebApi.Controllers;

[ApiController]
[Route("api/courses/{courseId:guid}/modules/{moduleId:guid}/lessons")]
public class LessonsController : ControllerBase
{
    private readonly ILessonsService service;
    private readonly JsonOptions jsonOptions;
    private static readonly ConcurrentDictionary<LessonTypeDto, Type> LessonContentDtoTypes = new();
    private static readonly ConcurrentDictionary<Type, LessonTypeDto> LessonContentTypesDto = new();
    private static readonly ConcurrentDictionary<Type, Type> DtoTypesByModel = new();

    public LessonsController(IOptions<JsonOptions> jsonOptions, ILessonsService service)
    {
        this.service = service;
        this.jsonOptions = jsonOptions.Value;
    }

    /// <summary>
    /// Добавить уроки в модуль
    /// </summary>
    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [SwaggerRequestExample(typeof(PostLessonDto), typeof(PostLessonExample))]
    public async Task<ActionResult> PostLessonsToModule(Guid courseId, Guid moduleId,
        [FromBody] PostLessonDto[] lessons)
    {
        var modelLessons = lessons.Select(lesson =>
        {
            var lessonContentJson = (JsonElement)lesson.Value;
            var lessonDto = (LessonContentBaseDto)lessonContentJson.Deserialize(GetLessonContentType(lesson.Type),
                jsonOptions.JsonSerializerOptions)!;
            var lessonModel =
                (LessonContent)lessonDto.Adapt(lessonDto.GetType(), lessonDto.GetModelLessonContentType())!;
            lessonModel.Name = lesson.Name;
            return lessonModel;
        });

        await service.PostLessons(courseId, moduleId, modelLessons);
        return Ok();
    }

    /// <summary>
    /// Получить уроки из модуля
    /// </summary>
    [HttpGet]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetLessonExample))]
    public async Task<ActionResult<GetLessonDto[]>> GetLessonsFromModule(Guid courseId, Guid moduleId)
    {
        var lessons = await service.GetLessons(courseId, moduleId);
        var result = lessons.Select(w =>
        {
            var modelType = w.GetType();
            var dtoType = GetDtoTypeFromModel(modelType);
            var dto = (LessonContentBaseDto)w.Adapt(modelType, dtoType)!;
            return new GetLessonDto(w.Id, w.Name, GetLessonTypeDto(dto), dto);
        });
        return Ok(result.ToArray());
    }

    private static Type GetLessonContentType(LessonTypeDto lessonTypeDto) =>
        LessonContentDtoTypes.GetOrAdd(lessonTypeDto, typeDto => Assembly.GetExecutingAssembly().GetTypes()
            .Single(t => t.GetCustomAttribute<LessonDtoTypeAttribute>()?.LessonType == typeDto));

    private static LessonTypeDto GetLessonTypeDto(LessonContentBaseDto dto) =>
        LessonContentTypesDto.GetOrAdd(dto.GetType(),
            type => type.GetCustomAttribute<LessonDtoTypeAttribute>()?.LessonType ??
                    throw new InvalidOperationException());

    private static Type GetDtoTypeFromModel(Type modelType)
    {
        return DtoTypesByModel.GetOrAdd(modelType, modelT =>
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(LessonContentBaseDto))
                .Where(dtoType =>
                {
                    var constructor = dtoType.GetConstructor(Array.Empty<Type>()) ??
                                      throw new InvalidOperationException();
                    var obj = constructor.Invoke(Array.Empty<object>());
                    var method = dtoType.GetMethod(nameof(LessonContentBaseDto.GetModelLessonContentType))!;
                    return (Type)method.Invoke(obj, Array.Empty<object>())! == modelT;
                }).Single();
        });
    }
}