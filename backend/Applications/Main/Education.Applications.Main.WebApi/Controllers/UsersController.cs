using System.Net;
using Education.Applications.Common.Constants;
using Education.Applications.Main.WebApi.Dto.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    [HttpPost]
    [Route("")]
    [SwaggerResponse((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> PostUser([FromBody] PostUserDto userDto)
    {
        var user = new IdentityUser<Guid>(userDto.Name);
        var result = await userManager.CreateAsync(user, userDto.Password);
        if (!result.Succeeded) return BadRequest();

        await userManager.AddToRoleAsync(user, Roles.User);
        await signInManager.PasswordSignInAsync(userDto.Name, userDto.Password, userDto.IsPersistent, false);
        return NoContent();
    }

    /// <summary>
    /// Логин
    /// </summary>
    [HttpPost]
    [Route("login")]
    [SwaggerResponse((int)HttpStatusCode.NoContent)]
    public async Task<ActionResult> Login([FromBody] PostUserDto user)
    {
        var result = await signInManager.PasswordSignInAsync(user.Name, user.Password, user.IsPersistent, false);
        if (result.Succeeded)
        {
            return NoContent();
        }

        return BadRequest();
    }
}