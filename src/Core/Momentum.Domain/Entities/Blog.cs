using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Entities;

public class Blog : IEntity, IAuditable
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }


    public string AuthorId { get; set; } = null!;
    public Guid ProfileImageId { get; set; }
    public Guid BannerImageId { get; set; }

    public AppUser? Author { get; set; }
    public Image? ProfileImage { get; set; }
    public Image? BannerImage { get; set; }
    public ICollection<Category>? Categories { get; set; }
    public ICollection<Tag>? Tags { get; set; }
    public ICollection<Post>? Posts { get; set; }
}
