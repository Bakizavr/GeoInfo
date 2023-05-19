namespace GeoInfo.Models
{
    public static class ConvertTimeZonesToDigital
    {
        private static Dictionary<string, int> TimeZones = new ()
        {
            {"Europe/Kaliningrad", 0},
            {"Europe/Moscow", 1},
            {"Europe/Samara", 2},
            {"Asia/Yekaterinburg", 3},
            {"Asia/Omsk", 4},
            {"Asia/Krasnoyarsk", 5},
            {"Asia/Irkutsk", 6},
            {"Asia/Yakutsk", 7},
            {"Asia/Vladivostok", 8},
            {"Asia/Magadan", 9},
            {"Asia/Kamchatka", 10},
        };

        public static int GetValueFromTimeZones(string timeZone)
        {
            var timeOfCity = TimeZones[timeZone];
            
            return timeOfCity;
        }
    }
}
