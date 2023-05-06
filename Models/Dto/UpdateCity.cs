namespace GeoInfo.Models
{
    public class UpdateCity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string AsciiName { get; set; }


        public string AlternateName { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string FeatureClass { get; set; }

        public string FeatureCode { get; set; }

        public string CountryCode { get; set; }

        public string Cc2 { get; set; }

        public string Admin1Code { get; set; }

        public string Admin2Code { get; set; }

        public string Admin3Code { get; set; }

        public string Admin4Code { get; set; }

        public int Population { get; set; }

        public int Elevation { get; set; }

        public int Dem { get; set; }

        public string TimeZone { get; set; }
    }
}
