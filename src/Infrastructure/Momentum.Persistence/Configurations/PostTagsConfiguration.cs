using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.Configurations;

public class PostTagsConfiguration : IEntityTypeConfiguration<PostTags>
{
    public void Configure(EntityTypeBuilder<PostTags> builder)
    {
        builder.HasKey(postTags => postTags.Id);

        builder.HasOne(postTags => postTags.Post)
               .WithMany(post => post.PostTags)
               .HasForeignKey(postTags => postTags.PostId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(postTags => postTags.Tag)
               .WithMany(tag => tag.PostTags)
               .HasForeignKey(postTags => postTags.TagId)
               .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
