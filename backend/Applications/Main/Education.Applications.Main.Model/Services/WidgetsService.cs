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

        var entityWidgetsDetails = widgets.Select(GetWidgetDetailsEntityFromModel).ToArray();
        var entityWidgets = new Widget[widgets.Length];
        for (var i = 0; i < widgets.Length; i++)
        {
            var widget = new Widget
                { Order = i, Type = entityWidgetsDetails[i].GetWidgetType(), ChapterId = chapterId };
            widget.SetWidgetDetails(entityWidgetsDetails[i]);
            entityWidgets[i] = widget;
        }

        var lastWidgetOrder = await widgetsRepository.FindLastWidgetIdInChapter(chapterId) ?? -1;
        await widgetsRepository.AddWidgets(entityWidgets.OrderElements(lastWidgetOrder + 1));
    }

    private static WidgetDetailsBase GetWidgetDetailsEntityFromModel(WidgetContent widgetContent) =>
        widgetContent switch
        {
            LiteratureWidgetModel literatureWidget => new LiteratureWidget
            {
                LiteratureElements = literatureWidget.Elements.Select(e => new LiteratureElement
                {
                    Name = e.Name,
                    Description = e.Description,
                    CoverSrc = e.CoverSrc,
                    PurchaseLinks = e.PurchaseLinks
                        .Select(pl => new LiteraturePurchaseLink { Value = pl })
                        .ToArray()
                        .OrderElements()
                }).ToArray().OrderElements()
            },
            PresentationWidgetModel presentationWidget => new PresentationWidget
            {
                PresentationSlides = presentationWidget.Slides
                    .Select(s => new PresentationSlide
                    {
                        ImageSrc = s.ImageSrc,
                        Description = s.Description,
                        VoiceSrc = s.VoiceSrc
                    }).ToArray().OrderElements()
            },
            VideoWidgetModel videoWidget => new VideoWidget
            {
                Src = videoWidget.Src,
                VideoType = videoWidget.VideoType.Adapt<VideoType>()
            },
            _ => throw new ArgumentOutOfRangeException(nameof(widgetContent))
        };
}