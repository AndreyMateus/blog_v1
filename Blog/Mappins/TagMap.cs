using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Mappins;

public class TagMap : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tag");
        builder.HasKey(builderTag => builderTag.Id);

        builder.Property(builderTag => builderTag.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();
        
        builder.Property(builderTag => builderTag.Name)
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(builderTag => builderTag.Slug)
        .HasColumnName("Slug") 
        .HasColumnType("NVARCHAR")
        .HasMaxLength(40)
        .IsRequired();
    }
}
