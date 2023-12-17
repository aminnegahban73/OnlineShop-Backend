using Web;
using Infrastructure;
using Application;
using Microsoft.AspNetCore.Diagnostics;
using Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configurations
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebConfigureServices(builder.Configuration);

// App Builder
var app = builder.Build();
await app.AddWebAppServices(); //await app.AddWebAppServices().ConfigureAwait(false);
