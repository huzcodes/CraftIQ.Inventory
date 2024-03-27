using CraftIQ.Inventory.Infrastructure.Data;
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
    }
}
