using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Mappins;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(builderUser => builderUser.Id);
        

        builder.Property(builderUser => builderUser.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();


        builder.Property(builderUser => builderUser.Name)
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(80)
        .IsRequired();

        builder.Property(builderUser => builderUser.Email)
        .HasColumnName("Email")
        .HasColumnType("VARCHAR")
        .HasMaxLength(240)
        .IsRequired();

        builder.Property(builderUser => builderUser.Password)
        .HasColumnName("Password")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(60)
        .IsRequired();

        builder.Property(builderUser => builderUser.Bio)
        .HasColumnName("Bio")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(255)
        .IsRequired();


        builder.Property(builderUser =>  builderUser.ImageUrl)
        .HasColumnName("ImageUrl")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(240)
        .IsRequired();

        builder.Property(builderUser => builderUser.Slug)
        .HasColumnName("Slug")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80)
        .IsRequired();
    }
}
