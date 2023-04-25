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
    public string Latitude { get; set; }

    /// <summary>
    /// Долгота в десятичных градусах
    /// </summary>
    public string Longitude { get; set; }

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
    public string Population { get; set; }

    /// <summary>
    /// Альтитуда (высота над уровнем моря)
    /// </summary>
    public string Elevation { get; set; }

    /// <summary>
    /// Цифровая модель рельефа
    /// </summary>
    public string Dem { get; set; }

    /// <summary>
    /// Часовой пояс (идентификатор)
    /// </summary>
    public string TimeZone { get; set; }

    /// <summary>
    /// Дата последней модификации в формате yyyy-MM-dd
    /// </summary>
    public string ModificationDate { get; set; }
}