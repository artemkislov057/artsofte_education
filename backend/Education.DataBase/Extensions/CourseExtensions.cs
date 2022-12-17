using Education.DataBase.Entities;
using Education.DataBase.Entities.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Extensions;

public static class CourseExtensions
{
    public static IQueryable<Course> IncludeModulesWithLessonDetails(this IQueryable<Course> source) =>
        typeof(Lesson).GetProperties()
            .Where(property => property.PropertyType.BaseType == typeof(LessonDetailsBase))
            .Aggregate(source, (current, property) =>
                current.Include($"{nameof(Course.Modules)}.{nameof(Module.Lessons)}.{property.Name}"));
}