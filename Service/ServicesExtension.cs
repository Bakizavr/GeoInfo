using GeoInfo.Service;

public static class ServicesExtension
{
    public static IServiceCollection RegistreServices(this IServiceCollection services)
    {
        services.AddScoped<CityService>();
        return services;
    }
}