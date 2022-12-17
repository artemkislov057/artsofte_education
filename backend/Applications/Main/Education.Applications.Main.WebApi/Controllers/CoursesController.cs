using System.Net;
using Education.Applications.Common.Constants;
using Education.Applications.Main.Model.Models.Courses;
using Education.Applications.Main.Model.Services;
using Education.Applications.Main.WebApi.Dto.Courses;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Education.Applications.Main.WebApi.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly ICoursesService coursesService;

    public CoursesController(ICoursesService coursesService)
    {
        this.coursesService = coursesService;
    }

    /// <summary>
    /// Добавить курс
    /// </summary>
    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    [SwaggerResponse((int)HttpStatusCode.Created)]
    public async Task<ActionResult<CourseDto>> AddCourse([FromBody] PostPutCourseDto courseDto)
    {
        var course = courseDto.Adapt<AddOrEditCourseModel>();
        var result = await coursesService.AddCourse(course);
        return Created(
            $"api/courses/{result.Id}",
            result.Adapt<CourseDto>()
        );
    }

    /// <summary>
    /// Удалить курс
    /// </summary>
    [HttpDelete]
    [Route("{courseId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Курс успешно удалён")]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Курс не найден")]
    public async Task<ActionResult> DeleteCourse(Guid courseId)
    {
        var result = await coursesService.TryDeleteCourse(courseId);
        return result ? NoContent() : NotFound();
    }

    /// <summary>
    /// Редактировать курс
    /// </summary>
    [HttpPut]
    [Route("{courseId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Курс успешно отредактирован")]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Курс не найден")]
    public async Task<ActionResult> EditCourse(Guid courseId, [FromBody] PostPutCourseDto courseDto)
    {
        var model = courseDto.Adapt<AddOrEditCourseModel>();
        await coursesService.EditCourse(courseId, model);
        return NoContent();
    }

    /// <summary>
    /// Получить доступные курсы
    /// </summary>
    [HttpGet]
    [Authorize]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<ActionResult<CourseDto[]>> GetCourses()
    {
        var courses = await coursesService.GetCourses();
        return Ok(courses.Adapt<CourseDto[]>());
    }

    /// <summary>
    /// Получить курс по его идентификатору
    /// </summary>
    [HttpGet]
    [Authorize]
    [Route("{courseId:guid}")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<ActionResult<CourseDto>> GetCourse(Guid courseId)
    {
        var course = await coursesService.FindCourse(courseId);
        if (course is null)
        {
            return NotFound();
        }

        var result = course.Adapt<CourseDto>();
        for (var i = 0; i < course.Modules.Length; ++i)
        {
            var moduleDto = result.Modules[i];
            var moduleModel = course.Modules[i];
            moduleDto.Lessons = moduleModel.Lessons.Select(LessonsController.MapGetLessonDtoFromModel).ToArray();
        }

        return Ok(result);
    }
}