using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(post => post.Id);

        builder.Property(post => post.Id)
               .ValueGeneratedOnAdd();

        builder.Property(post => post.Title)
               .HasMaxLength(512)
               .IsRequired();

        builder.Property(post => post.Content)
               .HasMaxLength(32767)
               .IsRequired();

        builder.Property(post => post.IsPublished)
               .HasDefaultValue(false);

        builder.Property(post => post.CreatedAt)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(post => post.LastUpdatedAt)
               .ValueGeneratedOnAddOrUpdate()
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(post => post.AppUser)
               .WithMany(user => user.Posts)
               .HasForeignKey(post => post.AppUserId)
               .IsRequired();

        builder.HasOne(post => post.Category)
               .WithMany(category => category.Posts)
               .HasForeignKey(post => post.CategoryId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
