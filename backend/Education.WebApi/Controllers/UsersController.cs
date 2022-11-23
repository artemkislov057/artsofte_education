using Education.Model.Services;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUsersService usersService;

    public UsersController(IUsersService usersService)
    {
        this.usersService = usersService;
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        return Ok(await usersService.Get(id));
    }
}