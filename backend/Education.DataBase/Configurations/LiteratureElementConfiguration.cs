using Education.DataBase.Entities.Lessons.LessonContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.DataBase.Configurations;

public class LiteratureElementConfiguration : IEntityTypeConfiguration<LiteratureElement>
{
    public void Configure(EntityTypeBuilder<LiteratureElement> builder)
    {
        builder.Navigation(e => e.PurchaseLinks).AutoInclude();
    }
}