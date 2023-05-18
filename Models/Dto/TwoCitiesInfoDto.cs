namespace GeoInfo.Models
{
    public class TwoCitiesInfoDto
    {
        public TwoCitiesInfoDto(IEnumerable<City> data, string latitude, string time) 
        {
            Data = data;
            LatitudeDifference = latitude;
            TimeDifference = time;
        }
        public IEnumerable<City> Data { get; set; }

        public string LatitudeDifference { get; set; }

        public string TimeDifference { get; set; }
    }
}
