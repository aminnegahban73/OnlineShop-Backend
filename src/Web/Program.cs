using Web;
using Infrastructure;
using Application;
using Microsoft.AspNetCore.Diagnostics;
using Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configurations
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebConfigureServices();

// App Builder
var app = builder.Build();
// Should be palced on the top due to will run at the end when error ocurred.
app.UseMiddleware<ExceptionsHandlerMiddleware>();
// Access To wwwroot
app.UseStaticFiles();
await app.AddWebAppServices(); //await app.AddWebAppServices().ConfigureAwait(false);
