using CraftIQ.Inventory.Core.Interfaces;
using CraftIQ.Inventory.Services.CategoriesImplementations;
using CraftIQ.Inventory.Services.Factories;
using CraftIQ.Inventory.Services.ProductsImplementations;
using Microsoft.Extensions.DependencyInjection;

namespace CraftIQ.Inventory.Services
{
    public static class ServicesRegistrations
    {
        public static void AddServicesRegistrations(this IServiceCollection services)
        {
            services.AddScoped(typeof(InventoryFactory<,>));
            services.AddScoped(typeof(IGenericServices<,>), typeof(CategoriesServices<,>));
            services.AddScoped(typeof(IGenericServices<,>), typeof(ProductsServices<,>));
        }
    }
}
