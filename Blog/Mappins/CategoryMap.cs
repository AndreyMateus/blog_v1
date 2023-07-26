using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Blog.Models;

namespace Blog.Mappins;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(category => category.Id);

        builder.Property(category => category.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        builder.Property(builderCategory => builderCategory.Name)
        .HasColumnName("Name")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80)
        .IsRequired();

        builder.Property(builderCategory => builderCategory.Slug)
        .HasColumnName("Slug")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80)
        .IsRequired();
        
        builder.HasMany(builderCategory => 
                builderCategory.Posts)
                .WithOne()
                .HasForeignKey("CategoryId")
                .HasConstraintName("FK_CategoryPost_CategoryId")
                .OnDelete(DeleteBehavior.Cascade);
    }
}
