using Education.DataBase.Entities.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Extensions;

public static class LessonExtensions
{
    public static void SetLessonDetails(this Lesson source, LessonDetailsBase details)
    {
        source.GetType()
            .GetProperties()
            .Single(p => p.PropertyType == details.GetType())
            .SetValue(source, details);
    }

    public static LessonDetailsBase GetLessonDetails(this Lesson source) =>
        source.GetType()
            .GetProperties()
            .Where(p => p.PropertyType.BaseType == typeof(LessonDetailsBase))
            .Select(p => (LessonDetailsBase?)p.GetValue(source))
            .Single(d => d != null)!;

    public static IQueryable<Lesson> IncludeLessonDetails(this IQueryable<Lesson> source) =>
        typeof(Lesson).GetProperties()
            .Where(p => p.PropertyType.BaseType == typeof(LessonDetailsBase))
            .Aggregate(source, (current, lessonDetailsProperty) => current.Include(lessonDetailsProperty.Name));
}