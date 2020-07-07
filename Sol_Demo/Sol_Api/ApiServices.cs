using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sol_Api.Repository;
using Sol_Api.Repository.DbModelContext;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Api
{
    public static class ApiServices
    {
        public static void AddPascalCaseIngoreNullPropertyJson(this IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions((leSetUp) =>
                {
                    // Pascal Casing
                    leSetUp.JsonSerializerOptions.PropertyNamingPolicy = null;

                    // Ignore Json Property Null Value from Response
                    leSetUp.JsonSerializerOptions.IgnoreNullValues = true;
                });
        }

        public static void AddMsSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFCoreContext>((leConfig) =>
            {
                leConfig.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void AddApiResponseCompression(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });
        }

        public static void AddUserRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}