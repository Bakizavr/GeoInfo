namespace GeoInfo.Models;
public class City
{
    /// <summary>
    ///  Идентификатор города
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Название города
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Название географической точки в виде простых символах ascii
    /// </summary>
    public string AsciiName { get; set; }

    /// <summary>
    /// Альтернативное название города
    /// </summary>
    public string AlternateName { get; set; }

    /// <summary>
    /// Широта в десятичных градусах
    /// </summary>
    public decimal Latitude { get; set; }

    /// <summary>
    /// Долгота в десятичных градусах
    /// </summary>
    public decimal Longitude { get; set; }

    /// <summary>
    /// Класс признака
    /// </summary>
    public string FeatureClass { get; set; }

    /// <summary>
    /// Класс кода
    /// </summary>
    public string FeatureCode { get; set; }

    /// <summary>
    /// Код страны
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// Альтернативные коды стран
    /// </summary>
    public string Cc2 { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Admin1Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Admin2Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Admin3Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string Admin4Code { get; set; }

    /// <summary>
    /// Население (кол-во жителей)
    /// </summary>
    public int Population { get; set; }

    /// <summary>
    /// Альтитуда (высота над уровнем моря)
    /// </summary>
    public int Elevation { get; set; }

    /// <summary>
    /// Цифровая модель рельефа
    /// </summary>
    public int Dem { get; set; }

    /// <summary>
    /// Часовой пояс (идентификатор)
    /// </summary>
    public string TimeZone { get; set; }

    /// <summary>
    /// Дата последней модификации в формате yyyy-MM-dd
    /// </summary>
    public DateTime ModificationDate { get; set; }

    public static City Create(long Id, string Name, string AsciiName, string AlternateName, decimal Latitude, decimal Longitude, string FeatureClass, string FeatureCode, string CountryCode, string Cc2, string Admin1Code, string Admin2Code, string Admin3Code, string Admin4Code, int Population, int Elevation, int Dem, string TimeZone)
    {
        var city = new City
        {
            Id = Id,
            Name = Name,
            AsciiName = AsciiName,
            AlternateName = AlternateName,
            Latitude = Latitude,
            Longitude = Longitude,
            FeatureClass = FeatureClass,
            FeatureCode = FeatureCode,
            CountryCode = CountryCode,
            Cc2 = Cc2,
            Admin1Code = Admin1Code,
            Admin2Code = Admin2Code,
            Admin3Code = Admin3Code,
            Admin4Code = Admin4Code,
            Population = Population,
            Elevation = Elevation,
            Dem = Dem,
            TimeZone = TimeZone,
            ModificationDate = DateTime.Now
        };
        return city;
    }

    //public static void Update(long Id, string Name, string AsciiName, string AlternateName, string Latitude, string Longitude, string FeatureClass, string FeatureCode, string CountryCode, string Cc2, string Admin1Code, string Admin2Code, string Admin3Code, string Admin4Code, string Population, string Elevation, string Dem, string TimeZone, string ModificationDate)
    //{
    //}
}