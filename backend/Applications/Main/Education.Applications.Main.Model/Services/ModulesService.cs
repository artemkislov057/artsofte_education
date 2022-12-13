using Education.DataBase.Entities;
using Education.DataBase.Repositories;

namespace Education.Applications.Main.Model.Services;

public interface IModulesService
{
    Task AddModuleToCourse(Guid courseId, Module module);
}

public class ModulesService : IModulesService
{
    private readonly ICoursesRepository coursesRepository;
    private readonly IModulesRepository modulesRepository;

    public ModulesService(ICoursesRepository coursesRepository, IModulesRepository modulesRepository)
    {
        this.coursesRepository = coursesRepository;
        this.modulesRepository = modulesRepository;
    }

    public async Task AddModuleToCourse(Guid courseId, Module module)
    {
        var course = await coursesRepository.FindCourseById(courseId);
        if (course is null)
        {
            // TODO: кинуть кастомное исключение
            return;
        }

        var lastOrder = await modulesRepository.FindLastOrderByCourseId(courseId) ?? -1;
        module.Order = lastOrder + 1;
        await modulesRepository.AddModuleToCourse(module, course);
    }
}