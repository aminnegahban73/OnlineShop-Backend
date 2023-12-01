using Web;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurations
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebServices();

var app = builder.Build();

// Add Scope
var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
// Get Services
var context = service.GetRequiredService<ApplicationDbContext>();
var loggerFactory = service.GetRequiredService<ILoggerFactory>();

try
{
    // Auto Migrations
    await context.Database.MigrateAsync();

    await GenerateFakeData.SeedDataAsync(context, loggerFactory);
}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, "An error occurred during migration.");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
