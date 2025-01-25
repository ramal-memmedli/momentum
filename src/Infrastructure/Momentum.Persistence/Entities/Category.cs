namespace Momentum.Domain.Entities;
public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Post>? Posts { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }
}
