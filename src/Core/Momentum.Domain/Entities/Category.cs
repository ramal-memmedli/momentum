using Momentum.Domain.Models.Abstract;

namespace Momentum.Domain.Entities;
public class Category : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Post>? Posts { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
