using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using Sample.Infrastructure.Interfaces.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Interfaces.Extensions
{
    public static class ServiceCollectionEXtensions
    {

        public static IServiceCollection AddMyContext(this IServiceCollection services, string ConncetionName)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.AddDbContext<SDbContext>(opts =>
            {
                opts.UseMySql(configuration.GetConnectionString(ConncetionName), builder => {
                    builder.CharSet(CharSet.Utf8Mb4);
                    builder.MinBatchSize(1);
                    builder.MaxBatchSize(100);
                
                });
                opts.EnableDetailedErrors();
            });
            services.AddScoped<DbContext, SDbContext>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
