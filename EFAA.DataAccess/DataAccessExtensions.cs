using EFAA.DataAccess.Interfaces;
using EFAA.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.DataAccess
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection AddDataAccessServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<QuotationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection") ??
                    throw new InvalidOperationException("connection string 'DbContext not found '"))
            );
            services.AddTransient(typeof(Interfaces.IEfRepository<>), typeof(Repositories.EfRepository<>));

            return services;
        }
    }
}