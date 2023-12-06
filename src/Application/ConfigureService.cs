﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ConfigureService
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}

