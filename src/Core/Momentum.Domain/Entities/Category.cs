using Momentum.Domain.Models.Abstract;

namespace Momentum.Domain.Entities;
public class Category : IEntity, IIdentifiable
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Post>? Posts { get; set; }
}
