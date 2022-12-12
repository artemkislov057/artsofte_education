﻿using Education.DataBase.Entities.Widgets;
using Education.DataBase.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Repositories;

public interface IWidgetsRepository
{
    Task AddWidgets(IEnumerable<Widget> widgets);
    Task<int?> FindLastWidgetIdInChapter(Guid chapterId);
}

public class WidgetsRepository : IWidgetsRepository
{
    private readonly EducationDbContext context;

    public WidgetsRepository(EducationDbContext context)
        => this.context = context;

    public async Task AddWidgets(IEnumerable<Widget> widgets)
    {
        context.AddRange(widgets);
        await context.SaveChangesAsync();
    }

    public async Task<int?> FindLastWidgetIdInChapter(Guid chapterId)
    {
        return await context.Widgets
            .Where(w => w.ChapterId == chapterId)
            .GetMaxOrder();
    }
}