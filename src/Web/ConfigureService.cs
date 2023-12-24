using Domain.Exceptions;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.SeedData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Web.Middleware;

namespace Web
{
    public static class ConfigureService
    {
        public static IServiceCollection AddWebConfigureServices(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            ApiBehaviorOptions(builder);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Cache Memory
            builder.Services.AddDistributedMemoryCache();
            // I HttpContext Accessor
            builder.Services.AddHttpContextAccessor();
            // CORS Policy
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    //.WithOrigins(
                    //    configuration["CorsAddress:HttpAddress"] ?? string.Empty,
                    //    configuration["CorsAddress:HttpsAddress"] ?? string.Empty);
                });
            });

            return builder.Services;
        }

        private static void ApiBehaviorOptions(WebApplicationBuilder builder)
        {
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .SelectMany(v => v.Value.Errors)
                    .Select(c => c.ErrorMessage).ToList();

                    return new BadRequestObjectResult(new ApiToReturn((int)HttpStatusCode.BadRequest, errors));
                };
            });
        }

        public static async Task<IApplicationBuilder> AddWebAppServices(this WebApplication app)
        {
            // Should be placed on the top due to will run at the end when error ocurred.
            app.UseMiddleware<ExceptionsHandlerMiddleware>();
            
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
            // Access To wwwroot
            app.UseStaticFiles();
            // CORS
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();
            app.MapControllers();
            //await app.RunAsync();
            app.Run();

            return app;

        }
    }
}
