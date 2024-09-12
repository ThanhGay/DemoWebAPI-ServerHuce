using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS.Product.Infrastructures;
using WS.Shared.Constant.Database;

namespace WS.Product.ApplicationService.Startup
{
    public static class ProductStartup
    {
        /// <summary>
        /// extension method to configure the product database
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assemblyName"></param>
        public static void ConfigureProduct(this WebApplicationBuilder builder, string? assemblyName)
        {
            builder.Services.AddDbContext<ProductDbContext>(
                options =>
                {
                    options.UseSqlServer(
                        builder.Configuration.GetConnectionString("Default"),
                        options =>
                        {
                            options.MigrationsAssembly(assemblyName);
                            options.MigrationsHistoryTable(
                                DbSchema.TableMigrationsHistory,
                                DbSchema.Product
                            );
                        }
                    );
                },
                ServiceLifetime.Scoped
            );

            //builder.Services.AddScoped<>();
        }
    }
}
