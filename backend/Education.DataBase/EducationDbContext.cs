using Education.DataBase.Entities;
using Education.DataBase.Entities.Widgets;
using Education.DataBase.Entities.Widgets.WidgetContent;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase;

public class EducationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public EducationDbContext(DbContextOptions<EducationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Widget> Widgets { get; set; }
    public DbSet<VideoWidget> VideoWidgets { get; set; }
    public DbSet<PresentationWidget> PresentationWidgets { get; set; }
    public DbSet<LiteratureWidget> LiteratureWidgets { get; set; }
    public DbSet<PresentationSlide> PresentationSlides { get; set; }
    public DbSet<LiteraturePurchaseLink> LiteraturePurchaseLinks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}