using Web;
using Infrastructure;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Configurations
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddWebConfigureServices();
// App Builder
var app = builder.Build();
// Access To wwwroot
app.UseStaticFiles();


await app.AddWebAppServices();

//await app.AddWebAppServices().ConfigureAwait(false);
