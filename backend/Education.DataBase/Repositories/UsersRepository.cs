using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface IUsersRepository
{
    Task<string?> GetUserName(Guid id);
    Task<IdentityUser<Guid>?> GetUser(Guid id);
}

public class UsersRepository : IUsersRepository
{
    private readonly EducationDbContext context;

    public UsersRepository(EducationDbContext context)
    {
        this.context = context;
    }
    
    public async Task<string?> GetUserName(Guid id) =>
        await context.Users.Where(u => u.Id == id).Select(u => u.UserName).FirstOrDefaultAsync();

    public async Task<IdentityUser<Guid>?> GetUser(Guid id)
        => await context.Users.FirstOrDefaultAsync(u => u.Id == id);
}