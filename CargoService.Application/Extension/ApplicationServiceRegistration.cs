using CargoService.Application.ServiceContracts;
using CargoService.Application.Services;
using CargoService.Domain.RepositoryContracts.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using FluentValidation;
using StackExchange.Redis;


namespace CargoService.Application.Extension
{
     public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationService (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITripService, TripService>();
            services.AddScoped<IFleetService, FleetService>();
            services.AddScoped<ILoadService, LoadService>();
            services.AddScoped<IBidService, BidService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var RedisConfiguration = configuration.GetSection("Redis")["ConnectionString"];
                return ConnectionMultiplexer.Connect(RedisConfiguration!); // "localhost:6379"
            });

            services.AddSingleton<IRedisService, RedisService>();

            //services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = "localhost:6379"; 
            //    options.InstanceName = "CargoService_";   
            //});
            return services;
        }
            }
}
