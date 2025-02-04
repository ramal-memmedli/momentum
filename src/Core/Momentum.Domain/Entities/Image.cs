using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Entities
{
    public class Image : IEntity, IAuditable
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = null!;
        public string AltText { get; set; } = null!;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastUpdatedAt { get; set; }
    }
}
