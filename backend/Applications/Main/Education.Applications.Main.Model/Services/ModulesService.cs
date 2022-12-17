using Education.Applications.Main.Model.Extensions;
using Education.Applications.Main.Model.Models.Courses;
using Education.Applications.Main.Model.Models.Modules;
using Education.DataBase.Entities;
using Education.DataBase.Repositories;
using Mapster;

namespace Education.Applications.Main.Model.Services;

public interface IModulesService
{
    Task<ModuleModel> AddModuleToCourse(Guid courseId, AddOrEditCourseModel moduleModel);
    Task<bool> TryDeleteModule(Guid courseId, Guid moduleId);
    Task EditModel(Guid courseId, Guid moduleId, AddOrEditModuleModel moduleModel);
    Task ChangeOrder(Guid courseId, Guid[] orderIds);
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

    public async Task<ModuleModel> AddModuleToCourse(Guid courseId, AddOrEditCourseModel moduleModel)
    {
        var course = await coursesRepository.FindCourseById(courseId);
        if (course is null)
        {
            // TODO: кинуть кастомное исключение
            return null!;
        }

        var moduleEntity = moduleModel.Adapt<Module>();
        var lastOrder = await modulesRepository.FindLastOrderByCourseId(courseId) ?? -1;
        moduleEntity.Order = lastOrder + 1;
        await modulesRepository.AddModuleToCourse(moduleEntity, course);
        return moduleEntity.Adapt<ModuleModel>();
    }

    public async Task<bool> TryDeleteModule(Guid courseId, Guid moduleId)
    {
        var module = await modulesRepository.FindModule(moduleId);
        if (module is null)
        {
            return false;
        }

        if (module.CourseId != courseId)
        {
            // TODO: кинуть кастомное исключение
            return false;
        }

        await modulesRepository.DeleteModule(module);
        return true;
    }

    public async Task EditModel(Guid courseId, Guid moduleId, AddOrEditModuleModel moduleModel)
    {
        var moduleEntity = await modulesRepository.FindModule(moduleId);
        if (moduleEntity is null)
        {
            // TODO: кинуть кастомное исключение
            return;
        }

        if (moduleEntity.CourseId != courseId)
        {
            // TODO: кинуть кастомное исключение
            return;
        }

        moduleModel.Adapt(moduleEntity);
        await modulesRepository.EditModule(moduleEntity);
    }

    public async Task ChangeOrder(Guid courseId, Guid[] orderIds)
    {
        var modules = await modulesRepository.GetModulesFromCourse(courseId);
        modules.ChangeOrder(orderIds);
        await modulesRepository.EditModules(modules);
    }
}