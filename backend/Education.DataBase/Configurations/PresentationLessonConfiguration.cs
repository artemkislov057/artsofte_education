using Education.DataBase.Entities.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.DataBase.Configurations;

public class PresentationLessonConfiguration : IEntityTypeConfiguration<PresentationLesson>
{
    public void Configure(EntityTypeBuilder<PresentationLesson> builder)
    {
        builder.Navigation(e => e.PresentationSlides).AutoInclude();
    }
}