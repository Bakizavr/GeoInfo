using GeoInfo;
using GeoInfo.ApplicationdbContext;
using GeoInfo.Service;
using Microsoft.EntityFrameworkCore;
using IHost = Microsoft.Extensions.Hosting.IHost;
namespace GeoInfo.Extensions;

public static class HostExtensions
{
    public static async Task MigrateDatabase(this IHost host/*,ILogger logger*/)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            await context.Database.MigrateAsync();

            var dbi = new DataBaseInitializator(context);

            await dbi.DataBaseInitializeAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

}