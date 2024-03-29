﻿using Education.DataBase.Entities;
using Education.DataBase.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface IModulesRepository
{
    Task<Module[]> GetModulesFromCourse(Guid courseId, bool withOrdering = false);
    Task AddModuleToCourse(Module module, Course course);
    Task<int?> FindLastOrderByCourseId(Guid courseId);
    Task<bool> IsExistsModuleByIdAndCourseId(Guid moduleId, Guid courseId);
    Task<Module?> FindModule(Guid moduleId);
    Task DeleteModule(Module module);
    Task EditModule(Module module);
    Task EditModules(Module[] modules);
}

public class ModulesRepository : IModulesRepository
{
    private readonly EducationDbContext context;

    public ModulesRepository(EducationDbContext context)
    {
        this.context = context;
    }

    public Task<Module[]> GetModulesFromCourse(Guid courseId, bool withOrdering = false)
    {
        var query = context.Modules.Where(m => m.CourseId == courseId);

        if (withOrdering)
        {
            query = query.OrderBy(m => m.Order);
        }

        return query.ToArrayAsync();
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

    public async Task<Module?> FindModule(Guid moduleId) =>
        await context.Modules.SingleOrDefaultAsync(m => m.Id == moduleId);

    public async Task DeleteModule(Module module)
    {
        context.Modules.Remove(module);
        await context.SaveChangesAsync();
    }

    public async Task EditModule(Module module)
    {
        await context.SaveChangesAsync();
    }

    public async Task EditModules(Module[] modules)
    {
        await context.SaveChangesAsync();
    }
}