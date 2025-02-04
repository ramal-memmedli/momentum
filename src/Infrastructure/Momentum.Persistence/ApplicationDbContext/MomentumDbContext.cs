using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Momentum.Domain.Entities;
using Momentum.Persistence.Configurations;

namespace Momentum.Persistence.ApplicationDbContext;

public class MomentumDbContext : IdentityDbContext<AppUser>
{
    public MomentumDbContext(DbContextOptions<MomentumDbContext> options) : base(options) { }

    public DbSet<Image> Images { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTags> PostTags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration<AppUser>(new AppUserConfiguration());
        builder.ApplyConfiguration<Post>(new PostConfiguration());
        builder.ApplyConfiguration<Category>(new CategoryConfiguration());
        builder.ApplyConfiguration<Tag>(new TagConfiguration());
        builder.ApplyConfiguration<Blog>(new BlogConfiguration());
        builder.ApplyConfiguration<Image>(new ImageConfiguration());
        builder.ApplyConfiguration<PostTags>(new PostTagsConfiguration());
    }
}
