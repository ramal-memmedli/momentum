using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(user => user.Name)
               .HasMaxLength(64)
               .IsRequired();

        builder.Property(user => user.Surname)
               .HasMaxLength(64)
               .IsRequired();

        builder.Property(user => user.Title)
               .HasMaxLength(128)
               .IsRequired();

        builder.Property(user => user.CreatedAt)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(user => user.LastUpdatedAt)
               .ValueGeneratedOnAddOrUpdate()
               .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(user => user.ProfileImage)
               .WithMany()
               .HasForeignKey(user => user.ProfileImageId)
               .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(user => user.BannerImage)
               .WithMany()
               .HasForeignKey(user => user.BannerImageId)
               .OnDelete(DeleteBehavior.ClientNoAction);
    }
}
