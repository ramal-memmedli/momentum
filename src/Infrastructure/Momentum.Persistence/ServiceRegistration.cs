using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Momentum.Persistence.ApplicationDbContext;
namespace Momentum.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MomentumDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("momentumdb"));
            });
        }
    }
}
