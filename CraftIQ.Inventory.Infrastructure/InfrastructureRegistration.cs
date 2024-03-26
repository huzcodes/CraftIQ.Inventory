using CleanArchitecture.Infrastructure.Persistence;
using CraftIQ.Inventory.Core.Contracts.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static void AddInfrastructureRegistration(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
