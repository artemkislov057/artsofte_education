using Education.DataBase.Entities.Widgets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.DataBase.Configurations;

public class LiteratureWidgetConfiguration : IEntityTypeConfiguration<LiteratureWidget>
{
    public void Configure(EntityTypeBuilder<LiteratureWidget> builder)
    {
        builder.Navigation(e => e.LiteratureElements).AutoInclude();
    }
}