using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface IRolesRepository
{
    Task<IdentityRole<Guid>[]> GetUserRolesByUserId(Guid userId);
    Task<IdentityRole<Guid>?> GetRoleByName(string name);
}

public class RolesRepository : IRolesRepository
{
    private readonly EducationDbContext context;

    public RolesRepository(EducationDbContext context)
    {
        this.context = context;
    }

    public async Task<IdentityRole<Guid>[]> GetUserRolesByUserId(Guid userId)
    {
        var query =
            from role in context.Roles
            join userRole in context.UserRoles on role.Id equals userRole.RoleId
            where userRole.UserId == userId
            select role;

        return await query.ToArrayAsync();
    }

    public Task<IdentityRole<Guid>?> GetRoleByName(string name)
        => context.Roles.FirstOrDefaultAsync(r => r.Name == name);
}