using Education.Applications.Main.Model.Exceptions;
using Education.Applications.Main.Model.Extensions;
using Education.Applications.Main.Model.Models.Courses;
using Education.Applications.Main.Model.Models.Modules;
using Education.Applications.Main.Model.Services.EventSender.Events.Module;
using Education.Applications.Main.Model.Services.EventSender.Extensions;
using Education.DataBase.Entities;
using Education.DataBase.Repositories;
using Mapster;

namespace Education.Applications.Main.Model.Services;

public interface IModulesService
{
    Task<ModuleModel> AddModuleToCourse(Guid courseId, AddOrEditCourseModel moduleModel);
    Task<bool> TryDeleteModule(Guid courseId, Guid moduleId);
    Task EditModule(Guid courseId, Guid moduleId, AddOrEditModuleModel moduleModel);
    Task ChangeOrder(Guid courseId, Guid[] orderIds);
    Task<ModuleModel[]> GetModules(Guid courseId);
}

public class ModulesService : IModulesService
{
    private readonly ICoursesRepository coursesRepository;
    private readonly IModulesRepository modulesRepository;
    private readonly IEnumerable<EventSender.EventSender> eventSenders;

    public ModulesService(ICoursesRepository coursesRepository,
        IModulesRepository modulesRepository,
        IEnumerable<EventSender.EventSender>? eventSenders = null)
    {
        this.coursesRepository = coursesRepository;
        this.modulesRepository = modulesRepository;
        this.eventSenders = eventSenders ?? Enumerable.Empty<EventSender.EventSender>();
    }

    public async Task<ModuleModel> AddModuleToCourse(Guid courseId, AddOrEditCourseModel moduleModel)
    {
        var course = await coursesRepository.FindCourseById(courseId);
        if (course is null)
        {
            throw new NotFoundException("курс", courseId);
        }

        var moduleEntity = moduleModel.Adapt<Module>();
        var lastOrder = await modulesRepository.FindLastOrderByCourseId(courseId) ?? -1;
        moduleEntity.Order = lastOrder + 1;
        await modulesRepository.AddModuleToCourse(moduleEntity, course);
        var moduleResult = moduleEntity.Adapt<ModuleModel>();
        await eventSenders.Send(new ModuleAddEvent(course.Name, moduleResult));
        return moduleResult;
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
            throw new NotMatchException("курс", courseId, "модуль", moduleId);
        }

        await modulesRepository.DeleteModule(module);
        var course = await coursesRepository.FindCourse(courseId);
        await eventSenders.Send(new ModuleDeleteEvent(course!.Name, module.Name));
        return true;
    }

    public async Task EditModule(Guid courseId, Guid moduleId, AddOrEditModuleModel moduleModel)
    {
        var moduleEntity = await modulesRepository.FindModule(moduleId);
        if (moduleEntity is null)
        {
            throw new NotFoundException("модуль", moduleId);
        }

        if (moduleEntity.CourseId != courseId)
        {
            throw new NotMatchException("курс", courseId, "модуль", moduleId);
        }

        moduleModel.Adapt(moduleEntity);
        await modulesRepository.EditModule(moduleEntity);
        var course = await coursesRepository.FindCourse(courseId);
        await eventSenders.Send(new ModuleEditEvent(course!.Name, moduleEntity.Adapt<ModuleModel>()));
    }

    public async Task ChangeOrder(Guid courseId, Guid[] orderIds)
    {
        var modules = await modulesRepository.GetModulesFromCourse(courseId);
        modules.ChangeOrder(orderIds);
        await modulesRepository.EditModules(modules);
        var course = await coursesRepository.FindCourse(courseId);
        await eventSenders.Send(
            new ModulesOrderEditEvent(
                course!.Name,
                modules
                    .OrderBy(m => m.Order)
                    .Select(m => m.Name)
                    .ToArray()
            )
        );
    }

    public async Task<ModuleModel[]> GetModules(Guid courseId)
    {
        var modulesEntity = await modulesRepository.GetModulesFromCourse(courseId, true);
        return modulesEntity.Adapt<ModuleModel[]>();
    }
}