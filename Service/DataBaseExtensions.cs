using GeoInfo.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace GeoInfo.Service
{
    public static class DataBaseExtensions
    {
        public static IServiceCollection RegisterDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//Исправляет проблему записи данных формата DateTime в БД
            return services;
        }
    }
}
