using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Entities;
public class Category : IEntity, IAuditable
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }

    public string BlogId { get; set; } = null!;

    public Blog? Blog { get; set; }
    public ICollection<Post>? Posts { get; set; }
}
