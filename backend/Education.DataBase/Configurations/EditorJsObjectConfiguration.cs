using Education.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.DataBase.Configurations;

public class EditorJsObjectConfiguration : IEntityTypeConfiguration<EditorJsObject>
{
    public void Configure(EntityTypeBuilder<EditorJsObject> builder)
    {
        builder.Navigation(e => e.Blocks).AutoInclude();
    }
}