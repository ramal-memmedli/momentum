using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Entities;

public class Tag : IEntity, IAuditable
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }

    public string BlogId { get; set; } = null!;

    public Blog? Blog { get; set; }
    public ICollection<PostTags>? PostTags { get; set; }
}
