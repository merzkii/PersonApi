using Infrastructure.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ServiceExtension
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {

            //IServiceCollection serviceCollection = services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PersonDb;Trusted_Connection=True;MultipleActiveResultSets=true;",
            b => b.MigrationsAssembly("PersonApi")));
            //services.AddScoped<IImageService, FFImageLoading.ImageService>();

        }
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //IServiceCollection serviceCollection = services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped<IImageService, FFImageLoading.ImageService>();

        }
    }
}
