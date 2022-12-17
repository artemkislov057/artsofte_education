using System.ComponentModel.DataAnnotations;
using Education.Applications.FileLoader.WebApi.Dto;
using Education.DataBase.Enums;
using Education.DataBase.Repositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Education.Applications.FileLoader.WebApi.Controllers;

[ApiController]
[Route("{fileType}")]
public class FileController : ControllerBase
{
    private readonly IFilesRepository filesRepository;
    private readonly AppSettings appSettings;

    public FileController(IConfiguration configuration, IFilesRepository filesRepository)
    {
        this.filesRepository = filesRepository;
        appSettings = configuration.Get<AppSettings>();
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> AddFile([Required] IFormFile file, [FromRoute] FileTypeDto fileType)
    {
        var fileExtension = Path.GetExtension(file.FileName);
        var guid = await filesRepository.CreateFile(fileType.Adapt<FileType>(), fileExtension, file.ContentType);
        var path = Path.Combine(
            appSettings.StorageDirectoryPath,
            fileType.ToString(),
            guid + fileExtension
        );

        await using (var fileStream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        var apiPath = $"{fileType}/{guid}";
        return Created(apiPath, new { path = apiPath });
    }

    [HttpGet]
    [Route("{fileGuid:guid}")]
    public async Task<ActionResult> GetFile([FromRoute] FileTypeDto fileType, Guid fileGuid)
    {
        var fileEntity = await filesRepository.FindFile(fileGuid);
        if (fileEntity is null || fileEntity.FileType != fileType.Adapt<FileType>())
        {
            return NotFound();
        }

        var path = Path.Combine(
            appSettings.StorageDirectoryPath,
            fileType.ToString(),
            fileGuid + fileEntity.FileExtension
        );
        var fileStream = System.IO.File.OpenRead(path);
        return File(fileStream, fileEntity.ContentType);
    }

    [HttpDelete]
    [Route("{fileGuid:guid}")]
    public async Task<ActionResult> DeleteFile([FromRoute] FileTypeDto fileType, Guid fileGuid)
    {
        var fileEntity = await filesRepository.FindFile(fileGuid);
        if (fileEntity is null || fileEntity.FileType != fileType.Adapt<FileType>())
        {
            return NotFound();
        }

        var path = Path.Combine(
            appSettings.StorageDirectoryPath,
            fileType.ToString(),
            fileGuid + fileEntity.FileExtension
        );
        System.IO.File.Delete(path);
        await filesRepository.DeleteFile(fileEntity);
        return NoContent();
    }
}