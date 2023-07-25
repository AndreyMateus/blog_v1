using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Blog.Models;

namespace Blog.Mappins;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {

        builder.ToTable("Role");
        builder.HasKey(builderRole => builderRole.Id);

        builder.Property(builderRole => builderRole.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        builder.Property(builderRole => builderRole.Name)
        .HasColumnName("Name")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80)
        .IsRequired();

        builder.Property(builderRole => builderRole.Slug)
        .HasColumnName("Slug")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80)
        .IsRequired();
    }
}
