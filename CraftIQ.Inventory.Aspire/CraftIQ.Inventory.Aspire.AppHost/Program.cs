var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CraftIQ_Inventory_API>("craftiq-inventory-api");

builder.Build().Run();
