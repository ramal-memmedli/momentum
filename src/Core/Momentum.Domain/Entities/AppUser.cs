using Microsoft.AspNetCore.Identity;
using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Entities;

public class AppUser : IdentityUser, IEntity, IAuditable
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Title { get; set; } = null!;

    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }


    public Guid ProfileImageId { get; set; }
    public Guid BannerImageId { get; set; }


    public Image ProfileImage { get; set; }
    public Image BannerImage { get; set; }
    public ICollection<Blog> Blogs { get; set; } = null!;
    public ICollection<Post> Posts { get; set; } = null!;
}
