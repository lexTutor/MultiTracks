using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MTEFDataAccess.Data;
using MTEFDataAccess.Infrastructure.Implementation;
using MTEFDataAccess.Infrastructure.Interfaces;
using MTEFDataAccess.Model;
using MTEFDataAccess.Repository;

namespace MTEFDataAccess.Extensions
{
    public static class ServiceCollectionInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContextPool<SQLContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(AutoMapperInitializer));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<ISongService, SongService>();

            return services;
        }
    }
}
