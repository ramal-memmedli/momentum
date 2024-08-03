using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(post => post.Title)
               .UseIdentityColumn()
               .HasMaxLength(128);

        builder.Property(post => post.Content)
               .IsRequired()
               .HasMaxLength(20000);

        builder.Property(post => post.IsPublished)
               .HasDefaultValue(false);

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
