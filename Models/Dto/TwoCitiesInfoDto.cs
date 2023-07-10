namespace GeoInfo
{
    public class TwoCitiesInfoDto
    {
        public TwoCitiesInfoDto(IEnumerable<City> data, string info)
        {
            Data = data;
            Info = info;
        }
        public IEnumerable<City> Data { get; set; }
        public string Info { get; set; }
    }
}
