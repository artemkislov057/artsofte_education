using Education.Applications.Common.Constants;
using Education.Applications.Main.Model.Services;
using Education.Applications.Main.WebApi.Dto.Chapters;
using Education.DataBase.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Education.Applications.Main.WebApi.Controllers;

[ApiController]
[Route("api/courses/{courseId:guid}/chapters")]
public class ChaptersController : ControllerBase
{
    private readonly IChaptersService chaptersService;

    public ChaptersController(IChaptersService chaptersService)
    {
        this.chaptersService = chaptersService;
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<ActionResult> PostChapter(Guid courseId, [FromBody] PostChapterDto chapterDto)
    {
        var chapterEntity = chapterDto.Adapt<Chapter>();
        await chaptersService.AddChapterToCourse(courseId, chapterEntity);
        return Ok(chapterDto.Adapt<ChapterDto>());
    }
}