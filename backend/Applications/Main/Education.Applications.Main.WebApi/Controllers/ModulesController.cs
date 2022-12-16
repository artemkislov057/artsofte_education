using System.Net;
using Education.Applications.Common.Constants;
using Education.Applications.Main.Model.Services;
using Education.Applications.Main.WebApi.Dto.Modules;
using Education.DataBase.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Education.Applications.Main.WebApi.Controllers;

[ApiController]
[Route("api/courses/{courseId:guid}/modules")]
public class ModulesController : ControllerBase
{
    private readonly IModulesService modulesService;

    public ModulesController(IModulesService modulesService)
    {
        this.modulesService = modulesService;
    }

    /// <summary>
    /// Добавить модуль в курс
    /// </summary>
    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    [SwaggerResponse((int)HttpStatusCode.Created)]
    public async Task<ActionResult> PostModule(Guid courseId, [FromBody] PostModuleDto moduleDto)
    {
        var moduleEntity = moduleDto.Adapt<Module>();
        await modulesService.AddModuleToCourse(courseId, moduleEntity);
        return Created($"api/courses/{courseId}/modules/{moduleEntity.Id}", moduleEntity.Adapt<ModuleDto>());
    }

    /// <summary>
    /// Удалить модуль
    /// </summary>
    [HttpDelete]
    [Route("{moduleId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Модуль успешно удалён")]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Модуль не найден")]
    public async Task<ActionResult> DeleteModule(Guid courseId, Guid moduleId)
    {
        var result = await modulesService.TryDeleteModule(courseId, moduleId);
        return result ? NoContent() : NotFound();
    }
}