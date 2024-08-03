using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Momentum.Domain.Entities;

namespace Momentum.Persistence.ApplicationDbContext;

public class MomentumDbContext : IdentityDbContext<AppUser>
{
    public MomentumDbContext(DbContextOptions<MomentumDbContext> options) : base(options) { }
}
