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
    Task PostWidgets(Guid courseId, Guid chapterId, IEnumerable<WidgetContent> widgets);
    Task<WidgetContent[]> GetWidgets(Guid courseId, Guid chapterId);
}

public class WidgetsService : IWidgetsService
{
    private readonly IWidgetsRepository widgetsRepository;
    private readonly IChaptersRepository chaptersRepository;
    private static readonly ConcurrentDictionary<Type, Type> ModelTypesByEntity = new();

    public WidgetsService(IWidgetsRepository widgetsRepository, IChaptersRepository chaptersRepository)
    {
        this.widgetsRepository = widgetsRepository;
        this.chaptersRepository = chaptersRepository;
    }

    public async Task PostWidgets(Guid courseId, Guid chapterId, IEnumerable<WidgetContent> widgets)
    {
        if (!await chaptersRepository.IsExistsChapterByIdAndCourseId(chapterId, courseId))
        {
            // TODO: кинуть кастомное исключение
            return;
        }

        var entityWidgets = widgets.Select(widget =>
        {
            var entityWidgetDetails = GetWidgetDetailsEntityFromModel(widget);
            var entityWidget = new Widget { Type = entityWidgetDetails.GetWidgetType(), ChapterId = chapterId };
            entityWidget.SetWidgetDetails(entityWidgetDetails);
            return entityWidget;
        }).ToArray();

        var lastWidgetOrder = await widgetsRepository.FindLastWidgetIdInChapter(chapterId) ?? -1;
        await widgetsRepository.AddWidgets(entityWidgets.OrderElements(lastWidgetOrder + 1));
    }

    public async Task<WidgetContent[]> GetWidgets(Guid courseId, Guid chapterId)
    {
        if (!await chaptersRepository.IsExistsChapterByIdAndCourseId(chapterId, courseId))
        {
            // TODO: кинуть кастомное исключение
            return Array.Empty<WidgetContent>();
        }

        var entityWidgets = await widgetsRepository.GetWidgets(chapterId);
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