using CraftIQ.Inventory.Infrastructure;
using CraftIQ.Inventory.Services;
using huzcodes.Extensions.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// adding db context registration
var inventoryDbConnectionString = builder.Configuration.GetSection("ConnectionStrings:InventoryDbConnection");
builder.Services.AddInventoryDbContext(inventoryDbConnectionString.Value!);
builder.Services.AddInfrastructureRegistrations();
builder.Services.AddServicesRegistrations();
builder.Services.AddLogging();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Register the exception handler extension
app.AddExceptionHandlerExtension();

app.UseAuthorization();

app.MapControllers();

app.Run();
