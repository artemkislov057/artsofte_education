using Education.Applications.Admin.WebApi.Dto.Roles;
using Education.Applications.Admin.WebApi.Dto.Users;
using Education.DataBase.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.Applications.Admin.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IRolesRepository rolesRepository;
    private readonly UserManager<IdentityUser<Guid>> userManager;
    private readonly IUsersRepository usersRepository;

    public UsersController(IRolesRepository rolesRepository, UserManager<IdentityUser<Guid>> userManager,
        IUsersRepository usersRepository)
    {
        this.rolesRepository = rolesRepository;
        this.userManager = userManager;
        this.usersRepository = usersRepository;
    }

    /// <summary>
    /// Получить список доступных ролей у пользователя
    /// </summary>
    [HttpGet]
    [Route("{userId:guid}/roles")]
    public async Task<ActionResult<RoleDto[]>> GetUserRoles(Guid userId)
    {
        var roles = await rolesRepository.GetUserRolesByUserId(userId);
        return Ok(roles.Select(r => new RoleDto(r.Name)));
    }

    /// <summary>
    /// Добавить роль пользователю
    /// </summary>
    [HttpPost]
    [Route("{userId:guid}/roles")]
    public async Task<ActionResult> AddRoleToUser(Guid userId, [FromBody] RoleDto role)
    {
        var user = await usersRepository.GetUser(userId);
        if (user == null)
        {
            return BadRequest();
        }

        var result = await userManager.AddToRoleAsync(user, role.Name);
        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }

    /// <summary>
    /// Получить список пользователей
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<UserDto[]>> GetUsers()
    {
        var users = await usersRepository.GetUsers();
        return Ok(users.Select(u => new UserDto(u.Id, u.UserName)));
    }
}