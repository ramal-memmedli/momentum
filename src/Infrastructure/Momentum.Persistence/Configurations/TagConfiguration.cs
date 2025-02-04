using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(tag => tag.Id);

        builder.Property(tag => tag.Id)
               .ValueGeneratedOnAdd();

        builder.Property(tag => tag.Name)
               .HasMaxLength(64)
               .IsRequired();

        builder.Property(tag => tag.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(tag => tag.LastUpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(tag => tag.Blog)
               .WithMany(blog => blog.Tags)
               .HasForeignKey(tag => tag.BlogId)
               .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
