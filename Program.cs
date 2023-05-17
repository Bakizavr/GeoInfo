using GeoInfo;
using GeoInfo.Extensions;
using GeoInfo.Models;
using GeoInfo.Service;
using Microsoft.OpenApi.Models;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;

/*Вместо этого "var connection = builder.Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connection));
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//Исправляет проблему записи данных формата DateTime в БД"
добавил метод расширения*/
services.RegistreDataBase(builder);

services.AddControllers();

services.RegistreServices();//Вместо этого "services.AddScoped<CityService>();" добавил метод расширения

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeoInfo", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.MigrateDatabase();
await app.RunAsync();