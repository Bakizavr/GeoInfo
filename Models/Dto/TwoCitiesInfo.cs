namespace GeoInfo.Models
{
    public class TwoCitiesInfo<T>
    {
        public TwoCitiesInfo(IEnumerable<T> data, string info) 
        {
            Data = data;
            Info = info;
        }
        public IEnumerable<T> Data { get; set; }

        public string Info { get; set; }
    }
}
