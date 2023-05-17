using GeoInfo.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoInfo.Service
{
    public static class RegistreDataBaseExtension
    {
        public static IServiceCollection RegistreDataBase(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//Исправляет проблему записи данных формата DateTime в БД
            return services;
        }
    }
}
