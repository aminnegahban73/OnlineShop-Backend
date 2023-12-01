using Infrastructure.Persistence;
using Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Web
{
    public static class ConfigureService
    {
        public static IServiceCollection AddWebConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Services;
        }


        public static async Task<IApplicationBuilder> AddWebAppServices(this WebApplication app)
        {
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

            //await app.RunAsync();
            app.Run();

            return app;

        }
    }
}
