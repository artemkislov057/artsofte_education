using System.ComponentModel.DataAnnotations;
using ceTe.DynamicPDF.Rasterizer;
using Education.DataBase.Enums;
using Education.DataBase.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Education.Applications.FileLoader.WebApi.Controllers;

[ApiController]
[Route("presentation")]
public class PresentationController : ControllerBase
{
    private readonly IFilesRepository filesRepository;
    private readonly AppSettings appSettings;

    public PresentationController(IConfiguration configuration, IFilesRepository filesRepository)
    {
        this.filesRepository = filesRepository;
        appSettings = configuration.Get<AppSettings>();
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> AddPresentation([Required] IFormFile file)
    {
        if (file.ContentType != "application/pdf")
        {
            return BadRequest();
        }

        byte[] pdfBytes;
        await using (var openReadStream = file.OpenReadStream())
        {
            pdfBytes = new byte[openReadStream.Length];
            await openReadStream.ReadAsync(pdfBytes);
        }

        var inputPdf = new InputPdf(pdfBytes);
        var rasterizer = new PdfRasterizer(inputPdf);
        var imagesBytes = rasterizer.Draw(ImageFormat.Jpeg, ImageSize.Dpi72);
        const string fileExtension = ".jpeg";
        var guids = await filesRepository.CreateFiles(
            FileType.Image,
            imagesBytes.Length,
            fileExtension,
            "image/jpeg"
        );
        var paths = guids.Select(g => Path.Combine(
            appSettings.StorageDirectoryPath,
            FileType.Image.ToString(),
            g + fileExtension
        )).ToArray();

        for (var i = 0; i < imagesBytes.Length; ++i)
        {
            var imageBytes = imagesBytes[i];
            await System.IO.File.WriteAllBytesAsync(paths[i], imageBytes);
        }

        return Created(
            string.Empty,
            new
            {
                Paths = guids.Select(g => $"{FileType.Image}/{g}")
            }
        );
    }
}