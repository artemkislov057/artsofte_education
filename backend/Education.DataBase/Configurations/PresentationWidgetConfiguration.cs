using Education.DataBase.Entities.Widgets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.DataBase.Configurations;

public class PresentationWidgetConfiguration : IEntityTypeConfiguration<PresentationWidget>
{
    public void Configure(EntityTypeBuilder<PresentationWidget> builder)
    {
        builder.Navigation(e => e.PresentationSlides).AutoInclude();
    }
}