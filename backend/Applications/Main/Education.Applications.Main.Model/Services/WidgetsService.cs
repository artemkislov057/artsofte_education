using System.Collections.Concurrent;
using System.Reflection;
using Education.Applications.Main.Model.Models.Widgets;
using Education.DataBase.Entities.Widgets;
using Education.DataBase.Extensions;
using Education.DataBase.Repositories;
using Mapster;

namespace Education.Applications.Main.Model.Services;

public interface IWidgetsService
{
    Task PostWidgets(Guid courseId, Guid moduleId, IEnumerable<WidgetContent> widgets);
    Task<WidgetContent[]> GetWidgets(Guid courseId, Guid moduleId);
}

public class WidgetsService : IWidgetsService
{
    private readonly IWidgetsRepository widgetsRepository;
    private readonly IModulesRepository modulesRepository;
    private static readonly ConcurrentDictionary<Type, Type> ModelTypesByEntity = new();

    public WidgetsService(IWidgetsRepository widgetsRepository, IModulesRepository modulesRepository)
    {
        this.widgetsRepository = widgetsRepository;
        this.modulesRepository = modulesRepository;
    }

    public async Task PostWidgets(Guid courseId, Guid moduleId, IEnumerable<WidgetContent> widgets)
    {
        if (!await modulesRepository.IsExistsModuleByIdAndCourseId(moduleId, courseId))
        {
            // TODO: кинуть кастомное исключение
            return;
        }

        var entityWidgets = widgets.Select(widget =>
        {
            var entityWidgetDetails = GetWidgetDetailsEntityFromModel(widget);
            var entityWidget = new Widget { Type = entityWidgetDetails.GetWidgetType(), ModuleId = moduleId };
            entityWidget.SetWidgetDetails(entityWidgetDetails);
            return entityWidget;
        }).ToArray();

        var lastWidgetOrder = await widgetsRepository.FindLastWidgetIdInModule(moduleId) ?? -1;
        await widgetsRepository.AddWidgets(entityWidgets.OrderElements(lastWidgetOrder + 1));
    }

    public async Task<WidgetContent[]> GetWidgets(Guid courseId, Guid moduleId)
    {
        if (!await modulesRepository.IsExistsModuleByIdAndCourseId(moduleId, courseId))
        {
            // TODO: кинуть кастомное исключение
            return Array.Empty<WidgetContent>();
        }

        var entityWidgets = await widgetsRepository.GetWidgets(moduleId);
        var models = entityWidgets.Select(ew =>
        {
            var entityWidgetDetails = ew.GetWidgetDetails();
            var entityWidgetDetailsType = entityWidgetDetails.GetType();
            var widgetContentType = GetWidgetContentTypeByEntity(entityWidgetDetailsType);
            var widgetContentModel =
                (WidgetContent)entityWidgetDetails.Adapt(entityWidgetDetailsType, widgetContentType)!;
            widgetContentModel.Id = ew.Id;
            return widgetContentModel;
        });
        return models.ToArray();
    }

    private static WidgetDetailsBase GetWidgetDetailsEntityFromModel(WidgetContent widgetContent)
        => (WidgetDetailsBase)widgetContent.Adapt(widgetContent.GetType(), widgetContent.EntityType)!;

    private static Type GetWidgetContentTypeByEntity(Type entityType)
    {
        return ModelTypesByEntity.GetOrAdd(entityType, entityT =>
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.BaseType == typeof(WidgetContent))
                .Where(dtoType =>
                {
                    var constructor = dtoType.GetConstructor(Array.Empty<Type>()) ??
                                      throw new InvalidOperationException();
                    var obj = constructor.Invoke(Array.Empty<object>());
                    var property = dtoType.GetProperty(nameof(WidgetContent.EntityType))!;
                    return (Type)property.GetValue(obj)! == entityT;
                }).Single();
        });
    }
}