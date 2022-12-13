using Education.DataBase.Entities;
using Education.DataBase.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface IModulesRepository
{
    Task AddModuleToCourse(Module module, Course course);
    Task<int?> FindLastOrderByCourseId(Guid courseId);
    Task<bool> IsExistsModuleByIdAndCourseId(Guid moduleId, Guid courseId);
}

public class ModulesRepository : IModulesRepository
{
    private readonly EducationDbContext context;

    public ModulesRepository(EducationDbContext context)
    {
        this.context = context;
    }

    public async Task AddModuleToCourse(Module module, Course course)
    {
        module.CourseId = course.Id;
        context.Modules.Add(module);
        await context.SaveChangesAsync();
    }

    public async Task<int?> FindLastOrderByCourseId(Guid courseId)
    {
        return await context.Modules
            .Where(ch => ch.CourseId == courseId)
            .GetMaxOrder();
    }

    public async Task<bool> IsExistsModuleByIdAndCourseId(Guid moduleId, Guid courseId) =>
        await context.Modules.AnyAsync(ch => ch.Id == moduleId && ch.CourseId == courseId);
}