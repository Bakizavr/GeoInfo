using Microsoft.EntityFrameworkCore;

namespace GeoInfo;

/// <summary>
/// Контекст базы данных
/// </summary>
public sealed class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Конструктор контекста базы данных
    /// </summary>
    /// <param name="options">Параметры контекста</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    /// <summary>
    /// Города
    /// </summary>
    public DbSet<City> Cities { get; set; }
}