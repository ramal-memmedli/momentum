using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Momentum.Domain.Entities;
using Momentum.Persistence.Configurations;

namespace Momentum.Persistence.ApplicationDbContext;

public class MomentumDbContext : IdentityDbContext<AppUser>
{
    public MomentumDbContext(DbContextOptions<MomentumDbContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration<AppUser>(new AppUserConfiguration());
        builder.ApplyConfiguration<Post>(new PostConfiguration());
        builder.ApplyConfiguration<Category>(new CategoryConfiguration());
    }
}
