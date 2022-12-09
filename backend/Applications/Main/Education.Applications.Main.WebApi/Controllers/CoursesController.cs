using Education.Applications.Main.Model.Services;
using Education.Applications.Main.WebApi.Dto.Courses;
using Education.DataBase.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public async Task<ActionResult<CourseDto>> AddCourse([FromBody] PostCourseDto courseDto)
    {
        var courseEntity = courseDto.Adapt<Course>();
        await coursesService.AddCourse(courseEntity);
        return Ok(courseEntity.Adapt<CourseDto>());
    }

    [HttpGet]
    public async Task<ActionResult<CourseDto[]>> GetCourses()
    {
        var courses = await coursesService.GetCourses();
        return Ok(courses.Adapt<CourseDto[]>());
    }
}