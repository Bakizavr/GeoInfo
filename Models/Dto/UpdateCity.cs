namespace GeoInfo.Models
{
    public class UpdateCity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string AsciiName { get; set; }


        public string AlternateName { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string FeatureClass { get; set; }

        public string FeatureCode { get; set; }

        public string CountryCode { get; set; }

        public string Cc2 { get; set; }

        public string Admin1Code { get; set; }

        public string Admin2Code { get; set; }

        public string Admin3Code { get; set; }

        public string Admin4Code { get; set; }

        public string Population { get; set; }

        public string Elevation { get; set; }

        public string Dem { get; set; }

        public string TimeZone { get; set; }

        public string ModificationDate { get; set; }
        public static City UpdateCityDto(UpdateCity city)
        {
            if (city == null) return null;

            var dto = new City
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
                Admin1Code = city.Admin1Code,
                Admin2Code = city.Admin2Code,
                Admin3Code = city.Admin3Code,
                Admin4Code = city.Admin4Code,
                Population = city.Population,
                Elevation = city.Elevation,
                Dem = city.Dem,
                TimeZone = city.TimeZone,
                ModificationDate = city.ModificationDate,
            };
            return dto;
        }
    }
}
