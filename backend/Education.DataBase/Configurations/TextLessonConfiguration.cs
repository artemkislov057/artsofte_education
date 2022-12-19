using Education.DataBase.Entities.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.DataBase.Configurations;

public class TextLessonConfiguration : IEntityTypeConfiguration<TextLesson>
{
    public void Configure(EntityTypeBuilder<TextLesson> builder)
    {
        builder.Navigation(e => e.Blocks).AutoInclude();
    }
}