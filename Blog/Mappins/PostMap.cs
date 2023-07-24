using Microsoft.EntityFrameworkCore;
using Blog.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Mappins;

public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");
        builder.HasKey(builderPost => builderPost.Id);


        builder.Property(builderPost => builderPost.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();

        builder.Property(builderPost => builderPost.Title)
        .HasColumnName("Title")
        .HasColumnType("VARCHAR")
        .HasMaxLength(160)
        .IsRequired();

        builder.Property(builderPost => builderPost.Summary)
        .HasColumnName("Summary")
        .HasColumnType("VARCHAR")
        .HasMaxLength(255)
        .IsRequired();


        builder.Property(builderCategory => builderCategory.Body)
        .HasColumnName("Body")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(255)
        .IsRequired();

        builder.Property(builderCategory => builderCategory.Slug)
        .HasColumnName("Slug")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(450)
        .IsRequired();

        builder.Property(builderCategory => builderCategory.CreateDate)
        .HasColumnName("CreateDate")
        .HasColumnType("DATETIME")
        .HasDefaultValueSql("GETDATE()")// TODO: CONFERIR se a função está certa
        .IsRequired();

        builder.Property(builderCategory => builderCategory.LastUpdateDate)
        .HasColumnName("LastUpdateDate")
        .HasColumnType("SMALLDATETIME")
        .IsRequired();


        // TODO: Conferir os Deletes e Adicionar aqui
        builder.HasOne(post => post.Category)
        .WithMany(navigationExpression: category => category.Posts)
        .HasForeignKey(post => post.Id)
        .HasConstraintName("FK_Post_Category")
        .OnDelete(DeleteBehavior.Restrict);
    
        builder.HasOne(post => post.User)
        .WithMany(user => user.Posts)
        .HasForeignKey(post => post.Id)
        .HasConstraintName("FK_PostUser");
       
       builder.HasMany(post => post.Tags)
       .WithMany(tag => tag.Posts)
       .UsingEntity<Dictionary<string, Object>>(
        "TagPost",

   post => 
        post.HasOne<Tag>()
        .WithMany()
        .HasForeignKey("PostId")
        .HasConstraintName("FK_PostTag_PostId")
        .OnDelete(DeleteBehavior.Cascade),

        tag => 
        tag.HasOne<Post>()
        .WithMany()
        .HasForeignKey("TagId")
        .HasConstraintName("FK_TagPost_TagId")
        .OnDelete(DeleteBehavior.Cascade)
       );
        
    }
}
