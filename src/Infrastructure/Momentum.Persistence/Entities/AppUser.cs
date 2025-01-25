using Microsoft.AspNetCore.Identity;
using Momentum.Domain.Abstractions;

namespace Momentum.Domain.Entities;

public class AppUser : IdentityUser
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public ICollection<Post> Posts { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastUpdatedAt { get; set; }
}
