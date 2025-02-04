using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Entities;

public class Post : IEntity, IAuditable
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public bool IsPublished { get; set; }


    
    public DateTimeOffset PublishedAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }


    public string BlogId { get; set; } = null!;
    public string AuthorId { get; set; } = null!;
    public string CategoryId { get; set; } = null!;


    public Blog? Blog { get; set; }
    public AppUser? Author { get; set; }
    public Category? Category { get; set; }
    public ICollection<PostTags>? PostTags { get; set; }
}
