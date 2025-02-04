using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(blog => blog.Id);

        builder.Property(blog => blog.Title)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(Blog => Blog.Description)
               .HasMaxLength(1024);

        builder.Property(blog => blog.CreatedAt)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(blog => blog.LastUpdatedAt)
               .ValueGeneratedOnAddOrUpdate()
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(blog => blog.Author)
               .WithMany(user => user.Blogs)
               .HasForeignKey(blog => blog.AuthorId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(blog => blog.ProfileImage)
               .WithMany()
               .HasForeignKey(blog => blog.ProfileImageId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(blog => blog.BannerImage)
               .WithMany()
               .HasForeignKey(blog => blog.BannerImageId)
               .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
