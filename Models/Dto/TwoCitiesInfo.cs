namespace GeoInfo.Models
{
    public class TwoCitiesInfo
    {
        public TwoCitiesInfo(IEnumerable<City> data, string info) 
        {
            Data = data;
            Info = info;
        }
        public IEnumerable<City> Data { get; set; }

        public string Info { get; set; }
    }
}
