using System.Net;
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
    private readonly SignInManager<IdentityUser<Guid>> signInManager;

    public AccountController(UserManager<IdentityUser<Guid>> userManager,
        SignInManager<IdentityUser<Guid>> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    /// <summary>
    /// Получить доступные роли пользователя
    /// </summary>
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
    /// Выйти из аккаунта (удалить куки)
    /// </summary>
    [HttpPost]
    [Route("logout")]
    [SwaggerResponse((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return NoContent();
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