using GeoInfo.Models;
using Microsoft.EntityFrameworkCore;

public class DataBaseInitializator
{
    public ApplicationDbContext _context;
    public DataBaseInitializator(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public async Task DataBaseInitializeAsync()
    {
        if (await _context.Cities.AnyAsync())
            return;
        Console.WriteLine("Start read data");
        await _context.AddRangeAsync(GetCities());
        await _context.SaveChangesAsync();
        Console.WriteLine("Finish read data");
    }
    private IEnumerable<City> GetCities()
    {
        var lines = File.ReadLines("D:\\Lessons\\Geo\\NewProject\\RU.txt");
        foreach (var line in lines)
        {
            yield return Map(line);
        }
    }

    private City Map(string line)
    {
        var subs = line.Split('\t');
        var city = new City()
        {
            Id = int.Parse(subs[0]),
            Name = subs[1],
            AsciiName = subs[2],
            AlternateName = subs[3],
            Latitude = Decimal.Parse(subs[4]),
            Longitude = Decimal.Parse(subs[5]),
            FeatureClass = subs[6],
            FeatureCode = subs[7],
            CountryCode = subs[8],
            Cc2 = subs[9],
            Admin1Code = subs[10],
            Admin2Code = subs[11],
            Admin3Code = subs[12],
            Admin4Code = subs[13],
            Population = int.Parse(subs[14]),
            Elevation = int.Parse(subs[15]),
            Dem = int.Parse(subs[16]),
            TimeZone = subs[17],
            ModificationDate = DateTime.Parse(subs[18]),
        };
        return city;
    }
}