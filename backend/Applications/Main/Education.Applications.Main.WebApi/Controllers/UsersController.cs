using Education.Applications.Main.WebApi.Dto.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.Applications.Main.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserManager<IdentityUser<Guid>> userManager;
    private readonly SignInManager<IdentityUser<Guid>> signInManager;

    public UsersController(UserManager<IdentityUser<Guid>> userManager,
        SignInManager<IdentityUser<Guid>> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpPost]
    public async Task<ActionResult> PostUser([FromBody] PostUserDto user)
    {
        var result = await userManager.CreateAsync(new IdentityUser<Guid>(user.Name), user.Password);
        if (!result.Succeeded) return BadRequest();

        await signInManager.PasswordSignInAsync(user.Name, user.Password, false, false);
        return Ok();
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody] PostUserDto user)
    {
        var result = await signInManager.PasswordSignInAsync(user.Name, user.Password, false, false);
        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }
}