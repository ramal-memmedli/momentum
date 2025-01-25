namespace Momentum.Domain.Abstractions;

public abstract class Entity<TModel> : IIdentifiable, IAuditable
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }
}
