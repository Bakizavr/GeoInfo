using GeoInfo.Extensions;
using GeoInfo.Filters;
using GeoInfo.Service;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDataBase(builder.Configuration);

builder.Services.AddControllers(options => options.Filters.Add<CustomExceptionFilterAttribute>());

builder.Services.AddControllers();

builder.Services.AddServices();

builder.Services.AddSwagger();

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