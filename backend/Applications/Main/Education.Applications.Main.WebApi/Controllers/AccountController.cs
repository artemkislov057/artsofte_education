﻿using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Education.Applications.Main.WebApi.Controllers;

[ApiController]
[Route("api/account")]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser<Guid>> userManager;

    public AccountController(UserManager<IdentityUser<Guid>> userManager)
    {
        this.userManager = userManager;
    }

    /// <summary>
    /// Получить доступные роли пользователя
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("roles")]
    [SwaggerResponse((int)HttpStatusCode.OK)]
    public async Task<ActionResult<string[]>> GetAccountRoles()
    {
        var user = await userManager.GetUserAsync(User);
        var roles = await userManager.GetRolesAsync(user);
        return Ok(roles);
    }

    /// <summary>
    /// Удалить аккаунт
    /// </summary>
    [HttpDelete]
    [SwaggerResponse((int)HttpStatusCode.NoContent, "Аккаунт успешно удалён")]
    [SwaggerResponse((int)HttpStatusCode.NotFound, "Аккаунт не найден")]
    public async Task<ActionResult> DeleteAccount()
    {
        var user = await userManager.GetUserAsync(User);
        if (user is null)
        {
            return NotFound();
        }

        var result = await userManager.DeleteAsync(user);
        return result.Succeeded ? NoContent() : BadRequest();
    }
}