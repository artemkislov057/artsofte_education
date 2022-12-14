using Education.DataBase.Entities.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.DataBase.Configurations;

public class LiteratureLessonConfiguration : IEntityTypeConfiguration<LiteratureLesson>
{
    public void Configure(EntityTypeBuilder<LiteratureLesson> builder)
    {
        builder.Navigation(e => e.LiteratureElements).AutoInclude();
    }
}