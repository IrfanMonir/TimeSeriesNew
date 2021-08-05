using Application.Buildings;
using Application.DataFields;
using Application.Objects;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBuildingService, BuildingService>();
            services.AddTransient<IObjectsService, ObjectService>();
            services.AddTransient<IDataFieldService, DataFieldService>();
            return services;
        }
    }
}
