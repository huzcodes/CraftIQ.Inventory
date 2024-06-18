using CraftIQ.Inventory.Services.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CraftIQ.Inventory.Services
{
    public static class ServicesRegistrations
    {
        public static void AddServicesRegistrations(this IServiceCollection services)
        {
            services.AddScoped(typeof(InventoryFactory<,>));
        }
    }
}
