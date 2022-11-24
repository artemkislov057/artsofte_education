using Education.DataBase.Repositories;

namespace Education.Applications.Main.Model.Services;

public interface IUsersService
{
    Task<string> Get(Guid id);
}

public class UsersService : IUsersService
{
    private readonly IUsersRepository usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        this.usersRepository = usersRepository;
    }
    
    public async Task<string> Get(Guid id)
    {
        return await usersRepository.GetUserName(id) ?? "DefaultName";
    }
}