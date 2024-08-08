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
               .HasMaxLength(128)
               .IsRequired();

        builder.Property(post => post.Content)
               .HasMaxLength(20000)
               .IsRequired();

        builder.Property(post => post.IsPublished)
               .HasDefaultValue(false);

        builder.Property(post => post.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(post => post.AppUser)
               .WithMany(user => user.Posts)
               .HasForeignKey(post => post.AppUserId)
               .IsRequired();

        builder.HasOne(post => post.Category)
               .WithMany(category => category.Posts)
               .HasForeignKey(post => post.CategoryId)
               .IsRequired();
    }
}
