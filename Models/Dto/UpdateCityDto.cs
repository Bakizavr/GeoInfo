namespace GeoInfo.Models
{
    public class UpdateCityDto
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
    }
}
