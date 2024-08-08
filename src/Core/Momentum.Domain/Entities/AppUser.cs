using Microsoft.AspNetCore.Identity;
using Momentum.Domain.Models.Abstract;

namespace Momentum.Domain.Entities;

public class AppUser : IdentityUser, IEntity, IAuditable
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public ICollection<Post>? Posts { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
