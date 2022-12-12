using Education.Applications.Main.Model.Models.Widgets;
using Education.Applications.Main.Model.Models.Widgets.Literature;
using Education.Applications.Main.Model.Models.Widgets.Presentation;
using Education.Applications.Main.Model.Models.Widgets.Video;
using Education.DataBase.Entities.Widgets;
using Education.DataBase.Entities.Widgets.WidgetContent;
using Education.DataBase.Enums.Widgets;
using Education.DataBase.Extensions;
using Education.DataBase.Repositories;
using Mapster;

namespace Education.Applications.Main.Model.Services;

public interface IWidgetsService
{
    Task PostWidgets(Guid courseId, Guid chapterId, WidgetContent[] widgets);
}

public class WidgetsService : IWidgetsService
{
    private readonly IWidgetsRepository widgetsRepository;
    private readonly IChaptersRepository chaptersRepository;

    public WidgetsService(IWidgetsRepository widgetsRepository, IChaptersRepository chaptersRepository)
    {
        this.widgetsRepository = widgetsRepository;
        this.chaptersRepository = chaptersRepository;
    }

    public async Task PostWidgets(Guid courseId, Guid chapterId, WidgetContent[] widgets)
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

    private static WidgetDetailsBase GetWidgetDetailsEntityFromModel(WidgetContent widgetContent)
        => (WidgetDetailsBase)widgetContent.Adapt(widgetContent.GetType(), widgetContent.EntityType)!;
}