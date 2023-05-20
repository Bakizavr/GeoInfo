using GeoInfo.Models;
using Microsoft.EntityFrameworkCore;

public class DataBaseInitializator
{
    public ApplicationDbContext applicactionDbContext;
    public DataBaseInitializator(ApplicationDbContext applicationDbContext)
    {
        applicactionDbContext = applicationDbContext;
    }

    public async Task DataBaseInitializeAsync()
    {
        if (await applicactionDbContext.Cities.AnyAsync())
            return;
        Console.WriteLine("Start read data");
        await applicactionDbContext.AddRangeAsync(GetCities());
        await applicactionDbContext.SaveChangesAsync();
        Console.WriteLine("Finish read data");
    }
    private IEnumerable<City> GetCities()
    {
        var lines = File.ReadLines("InputFiles\\CityData.txt");
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
            Latitude = Decimal.TryParse(subs[4], out var lat) ? lat : 0,
            Longitude = Decimal.TryParse(subs[5], out var lon) ? lon : 0,
            FeatureClass = subs[6],
            FeatureCode = subs[7],
            CountryCode = subs[8],
            Cc2 = subs[9],
            Population = int.TryParse(subs[14], out var pop) ? pop : 0,
            Elevation = int.TryParse(subs[15], out var el) ? el : 0,
            Dem = int.TryParse(subs[16], out var dem) ? dem : 0,
            TimeZone = subs[17],
            ModificationDate = DateTime.TryParse(subs[18], out var mod) ? mod : DateTime.MinValue,
        };
        return city;
    }
}