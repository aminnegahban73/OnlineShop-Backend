using Web;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Configurations
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebConfigureServices();
// App Builder
var app = builder.Build();
await app.AddWebAppServices();
//await app.AddWebAppServices().ConfigureAwait(false);
