﻿using Education.Applications.Admin.WebApi.Dto.Roles;
using Education.Applications.Common.Constants;
using Education.DataBase.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Education.Applications.Admin.WebApi.Controllers;

[ApiController]
[Route("api/roles")]
public sealed class RolesController : ControllerBase
{
    private readonly RoleManager<IdentityRole<Guid>> roleManager;
    private readonly IRolesRepository rolesRepository;

    public RolesController(RoleManager<IdentityRole<Guid>> roleManager, IRolesRepository rolesRepository)
    {
        this.roleManager = roleManager;
        this.rolesRepository = rolesRepository;
    }

    /// <summary>
    /// Получить доступные на сервере роли
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<RoleDto[]>> GetRoles()
    {
        return Ok(await roleManager.Roles.Select(r => new RoleDto(r.Name)).ToArrayAsync());
    }

    /// <summary>
    /// Добавить используемые на сервере роли (User, Admin)
    /// </summary>
    [HttpPost]
    [Route("default")]
    public async Task<ActionResult> AddDefaultRoles()
    {
        await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.Admin));
        await roleManager.CreateAsync(new IdentityRole<Guid>(Roles.User));
        return Ok();
    }

    /// <summary>
    /// Добавить роль (не рекомендуется использовать, лучше - api/roles/default)
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> AddRole([FromBody] RoleDto role)
    {
        var result = await roleManager.CreateAsync(new IdentityRole<Guid>(role.Name));
        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }

    /// <summary>
    /// Удалить роль с сервера
    /// </summary>
    [HttpDelete]
    [Route("{role-name}")]
    public async Task<ActionResult> DeleteRole([FromRoute(Name = "role-name")] string roleName)
    {
        var role = await rolesRepository.GetRoleByName(roleName);
        if (role == null)
        {
            return BadRequest();
        }

        var result = await roleManager.DeleteAsync(role);
        return result.Succeeded
            ? Ok()
            : BadRequest();
    }
}