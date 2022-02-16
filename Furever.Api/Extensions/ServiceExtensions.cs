using Furever.Entities;
using Furever.Entities.Helpers;
using Furever.LoggerService;
using Furever.PhotoService;
using Furever.Repositories;
using Furever.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Furever.Api.Extensions
{
    public static class ServiceExtensions
    {
        // Configure Cross Origin Policies
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
            });

        // Configure IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options => { });

        // Configure Logger Service
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureCloudinaryService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        }

        public static void ConfigureRepositoriesService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRefugeRepository, RefugeRepository>();
            services.AddScoped<IPhotoManager, PhotoManager>();
            
        }

        // Configure Swagger
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                services.AddSwaggerGen(s => 
                { 
                    s.SwaggerDoc("v1", new OpenApiInfo 
                    { 
                        Title = "Furever Api", 
                        Version = "v1" 
                    }); 
                });
            });   
        }

        // Configure SQL Server
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlite(configuration.GetConnectionString("sqlConnection"), (b => b.MigrationsAssembly("Furever.Api"))));
                //opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), (b => b.MigrationsAssembly("Furever.Api"))));
        }

    }
}
