namespace GeoInfo.Models
{
    public class TimeZoneDict
    {
        public Dictionary<string, int> _timeZones { get; set; }
        public void Dict()
        {
            _timeZones = new Dictionary<string, int>();

            _timeZones.Add("Europe/Kaliningrad", 0);
            _timeZones.Add("Europe/Moscow", 1);
            _timeZones.Add("Europe/Samara", 2);
            _timeZones.Add("Asia/Yekaterinburg", 3);
            _timeZones.Add("Asia/Omsk", 4);
            _timeZones.Add("Asia/Krasnoyarsk", 5);
            _timeZones.Add("Asia/Irkutsk", 6);
            _timeZones.Add("Asia/Yakutsk", 7);
            _timeZones.Add("Asia/Vladivostok", 8);
            _timeZones.Add("Asia/Magadan", 9);
            _timeZones.Add("Asia/Kamchatka", 10);
        }
    }
}
