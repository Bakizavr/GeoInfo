namespace GeoInfo
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AsciiName { get; set; }

        public string AlternateName { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string FeatureClass { get; set; }

        public string FeatureCode { get; set; }

        public string CountryCode { get; set; }

        public string Cc2 { get; set; }

        public int Population { get; set; }

        public int Elevation { get; set; }

        public int Dem { get; set; }

        public string TimeZone { get; set; }

        /// <summary>
        /// Создание объекта DTO для модели города
        /// </summary>
        /// <param name="city">Сущность города из базы данных</param>
        /// <returns>Возврат объекта DTO</returns>
        public static CityDto CreateCityDto(City city) 
        {
            if (city == null) return null;

            var dto = new CityDto 
            {
                Id = city.Id,
                Name = city.Name,
                AsciiName = city.AsciiName,
                AlternateName = city.AlternateName,
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                FeatureClass = city.FeatureClass,
                FeatureCode = city.FeatureCode,
                CountryCode = city.CountryCode,
                Cc2 = city.Cc2,
                Population = city.Population,
                Elevation = city.Elevation,
                Dem = city.Dem,
                TimeZone = city.TimeZone
            };
            return dto;
        }
    }
}
