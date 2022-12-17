using Education.DataBase.Entities.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.DataBase.Configurations;

public class TestLessonConfiguration : IEntityTypeConfiguration<TestLesson>
{
    public void Configure(EntityTypeBuilder<TestLesson> builder)
    {
        builder.Navigation(e => e.Questions).AutoInclude();
    }
}