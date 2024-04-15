using CraftIQ.Inventory.Infrastructure.Data;
using huzcodes.Persistence.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CraftIQ.Inventory.Infrastructure
{
    public static class InfrastructureRegistrations
    {
        /// <summary>
        /// this function for adding sql server db context connection
        /// </summary>
        public static void AddInventoryDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connectionString));

        public static void AddInfrastructureRegistrations(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(InventoryRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(InventoryRepository<>));
        }
    }
}
