using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Entities;

public class PostTags : IEntity
{
    public int Id { get; set; }

    public Guid PostId { get; set; }
    public Guid TagId { get; set; }


    public Post? Post { get; set; }
    public Tag? Tag { get; set; }
}
