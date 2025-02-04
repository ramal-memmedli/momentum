using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(image => image.Id);

        builder.Property(image => image.Id)
               .ValueGeneratedOnAdd();

        builder.Property(image => image.Url)
                .HasMaxLength(248)
                .IsRequired();

        builder.Property(image => image.AltText)
                .HasMaxLength(128);

        builder.Property(image => image.CreatedAt)
               .HasDefaultValueSql("GETDATE()")
               .ValueGeneratedOnAdd();

        builder.Property(image => image.LastUpdatedAt)
               .HasDefaultValueSql("GETDATE()")
               .ValueGeneratedOnAddOrUpdate();
    }
}
