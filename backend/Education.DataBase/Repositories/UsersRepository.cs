using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface IUsersRepository
{
    Task<string?> GetUserName(Guid id);
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
}