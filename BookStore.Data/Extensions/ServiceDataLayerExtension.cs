﻿using BookStore.Data.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace BookStore.Data.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ServiceDataLayerExtension
    {
        public static void AddServiceDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = ConnectionStringProvider.GetConnectionString(configuration);
            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseNpgsql(connString);
            });

            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}