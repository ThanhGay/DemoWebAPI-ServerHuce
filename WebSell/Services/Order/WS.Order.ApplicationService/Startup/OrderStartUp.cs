
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Order.ApplicationService.CartManagerModule.Abstracts;
using WS.Order.ApplicationService.CartManagerModule.Implements;
using WS.Order.ApplicationService.OrderManagerModule.Abstracts;
using WS.Order.ApplicationService.OrderManagerModule.Implements;
using WS.Order.Infrastructures;
using WS.Shared.Constant.Database;

namespace WS.Order.ApplicationService.Startup
{
    public static class OrderStartUp
    {
        /// <summary>
        /// extension method to configure the order database
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblyName"></param>
        public static void ConfigureOrder(this WebApplicationBuilder builder, string? assemblyName)
        {
            builder.Services.AddDbContext<OrderDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Default"),
                        options =>
                        {
                            options.MigrationsAssembly(assemblyName);
                            options.MigrationsHistoryTable(
                                DbSchema.TableMigrationsHistory,
                                DbSchema.Order);
                        }
                    );
                },
                ServiceLifetime.Scoped
            );

            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<ICartService, CartService>();
        }
    }
}
