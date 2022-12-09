using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    [Route("roles")]
    public async Task<ActionResult<string[]>> GetAccountRoles()
    {
        var user = await userManager.GetUserAsync(User);
        var roles = await userManager.GetRolesAsync(user);
        return Ok(roles);
    }
}