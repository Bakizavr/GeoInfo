namespace GeoInfo;
public class City
{
    /// <summary>
    ///  Идентификатор города
    /// </summary>
    public int Id { get; set; }

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

    public static City Create(string name, string asciiName, string alternateName, decimal latitude, decimal longitude, string featureClass, string featureCode, string countryCode, string cc2, int population, int elevation, int dem, string timeZone)
    {
        var city = new City
        {
            Name = name,
            AsciiName = asciiName,
            AlternateName = alternateName,
            Latitude = latitude,
            Longitude = longitude,
            FeatureClass = featureClass,
            FeatureCode = featureCode,
            CountryCode = countryCode,
            Cc2 = cc2,
            Population = population,
            Elevation = elevation,
            Dem = dem,
            TimeZone = timeZone,
            ModificationDate = DateTime.UtcNow
        };
        return city;
    }
    //TODO: упростить
    //public static void Update(long Id, string Name, string AsciiName, string AlternateName, string Latitude, string Longitude, string FeatureClass, string FeatureCode, string CountryCode, string Cc2, string Population, string Elevation, string Dem, string TimeZone, string ModificationDate)
    //{
    //}
}