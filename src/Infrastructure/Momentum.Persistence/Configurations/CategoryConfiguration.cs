﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.Id);

        builder.Property(category => category.Name)
               .HasMaxLength(48)
               .HasDefaultValue("Unnamed category")
               .IsRequired();

        builder.Property(category => category.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAdd()
               .IsRequired();

        builder.Property(category => category.LastUpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()")
               .ValueGeneratedOnAddOrUpdate()
               .IsRequired();

        builder.HasOne(category => category.Blog)
               .WithMany(blog => blog.Categories)
               .HasForeignKey(category => category.BlogId)
               .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
