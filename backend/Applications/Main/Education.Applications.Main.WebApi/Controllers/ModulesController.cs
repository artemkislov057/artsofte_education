using System.Net;
using Education.Applications.Common.Constants;
using Education.Applications.Main.Model.Models.Courses;
using Education.Applications.Main.Model.Models.Modules;
using Education.Applications.Main.Model.Services;
using Education.Applications.Main.WebApi.Dto.Modules;
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
    [Route("")]
    [Authorize(Roles = Roles.Admin)]
    [SwaggerResponse((int)HttpStatusCode.Created)]
    public async Task<ActionResult<ModuleDto>> PostModule(Guid courseId, [FromBody] PostPutModuleDto moduleDto)
    {
        var moduleModel = moduleDto.Adapt<AddOrEditCourseModel>();
        var result = await modulesService.AddModuleToCourse(courseId, moduleModel);
        return Created($"api/courses/{courseId}/modules/{result.Id}", result.Adapt<ModuleDto>());
    }

    /// <summary>
    /// Получить модули курса
    /// </summary>
    [HttpGet]
    [Route("")]
    [Authorize]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<ActionResult<ModuleDto[]>> GetModules(Guid courseId)
    {
        var modules = await modulesService.GetModules(courseId);
        var result = modules.Adapt<ModuleDto[]>();
        return Ok(result);
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

    /// <summary>
    /// Редактировать модуль
    /// </summary>
    [HttpPut]
    [Route("{moduleId:guid}")]
    [Authorize(Roles = Roles.Admin)]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Модуль успешно отредактирован")]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Модуль не найден")]
    public async Task<ActionResult> EditModule(Guid courseId, Guid moduleId, [FromBody] PostPutModuleDto dto)
    {
        var model = dto.Adapt<AddOrEditModuleModel>();
        await modulesService.EditModel(courseId, moduleId, model);
        return NoContent();
    }

    /// <summary>
    /// Изменить порядок модулей в курсе
    /// </summary>
    /// <param name="courseId">Идентификатор курса</param>
    /// <param name="orders">Массив идентификаторов модулей в нужном порядке (обязательно должны быть все идентификаторы)</param>
    [HttpPost]
    [Route("change-order")]
    [Authorize(Roles = Roles.Admin)]
    [SwaggerResponse((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> ChangeOrder(Guid courseId, [FromBody] Guid[] orders)
    {
        await modulesService.ChangeOrder(courseId, orders);
        return NoContent();
    }
}