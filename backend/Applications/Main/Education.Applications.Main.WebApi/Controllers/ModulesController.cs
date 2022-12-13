using Education.Applications.Common.Constants;
using Education.Applications.Main.Model.Services;
using Education.Applications.Main.WebApi.Dto.Modules;
using Education.DataBase.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public async Task<ActionResult> PostModule(Guid courseId, [FromBody] PostModuleDto moduleDto)
    {
        var moduleEntity = moduleDto.Adapt<Module>();
        await modulesService.AddModuleToCourse(courseId, moduleEntity);
        return Ok(moduleEntity.Adapt<ModuleDto>());
    }
}