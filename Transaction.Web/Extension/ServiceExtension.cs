

using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transaction.Infrastructure.Persistance;
using Transaction.Infrastructure.Repositories;
using Transaction.Infrastructure.Repositories.Interfaces;
using Transaction.Services;
using Transaction.Services.Interfaces;

namespace Transaction.Web
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();          
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAllPolicy", corsBuilder.Build());
            });
        }



        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
         
            var connectionString = config["ConnectionStrings:TransactionDBContext"];
            services.AddDbContext<TransactionDBContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
        }

        public static void ConfigureServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IFileUploadService, FileUploadService>();
           
            services.AddScoped<ITransactionService, TransactionService>();
           
        }

    }
}
