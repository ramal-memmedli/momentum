using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(user => user.Name)
               .HasMaxLength(48)
               .IsRequired();

        builder.Property(user => user.Surname)
               .HasMaxLength(48)
               .IsRequired();

        builder.Property(user => user.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()");
    }
}
