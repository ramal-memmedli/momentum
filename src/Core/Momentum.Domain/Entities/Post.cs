using Momentum.Domain.Models.Abstract;

namespace Momentum.Domain.Entities;

public class Post : IEntity, IIdentifiable, IAuditable
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public bool IsPublished { get; set; }
    public DateTime? PublishedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
