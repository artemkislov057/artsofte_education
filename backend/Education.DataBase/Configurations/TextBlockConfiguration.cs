using Education.DataBase.Entities.Lessons.LessonContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.DataBase.Configurations;

public class TextBlockConfiguration : IEntityTypeConfiguration<TextBlock>
{
    public void Configure(EntityTypeBuilder<TextBlock> builder)
    {
        builder.Navigation(e => e.DataItems).AutoInclude();
    }
}