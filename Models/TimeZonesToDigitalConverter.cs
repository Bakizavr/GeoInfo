using System.Threading.Tasks;
namespace GeoInfo.Models;

public static class TimeZonesToDigitalConverter
{
    private static Dictionary<string, int> TimeZones = new()
    {
        {"Asia/Almaty", 6},
        {"Asia/Anadyr", 12},
        {"Asia/Aqtobe", 5},
        {"Asia/Ashgabat", 5},
        {"Asia/Baku", 4},
        {"Asia/Barnaul", 7},
        {"Asia/Chita", 9},
        {"Asia/Hovd", 7},
        {"Asia/Irkutsk", 8},
        {"Asia/Kamchatka", 12},
        {"Asia/Khandyga", 9},
        {"Asia/Krasnoyarsk", 7},
        {"Asia/Magadan", 11},
        {"Asia/Novokuznetsk", 7},
        {"Asia/Novosibirsk", 7},
        {"Asia/Omsk", 6},
        {"Asia/Qyzylorda", 5},
        {"Asia/Sakhalin", 11},
        {"Asia/Shanghai", 8},
        {"Asia/Srednekolymsk", 11},
        {"Asia/Tashkent", 5},
        {"Asia/Tbilisi", 4},
        {"Asia/Tokyo", 9},
        {"Asia/Tomsk", 7},
        {"Asia/Ulaanbaatar", 8},
        {"Asia/Ust-Nera", 10},
        {"Asia/Vladivostok", 10},
        {"Asia/Yakutsk", 9},
        {"Asia/Yekaterinburg", 5},
        {"Europe/Astrakhan", 4},
        {"Europe/Helsinki", 2},
        {"Europe/Kaliningrad", 2},
        {"Europe/Kirov", 3},
        {"Europe/Kyiv", 2},
        {"Europe/Minsk", 3},
        {"Europe/Monaco", 1},
        {"Europe/Moscow", 3},
        {"Europe/Oslo", 1},
        {"Europe/Paris", 1},
        {"Europe/Riga", 2},
        {"Europe/Samara", 4},
        {"Europe/Saratov", 4},
        {"Europe/Simferopol", 3},
        {"Europe/Ulyanovsk", 4},
        {"Europe/Vilnius", 2},
        {"Europe/Volgograd", 3},
        {"Europe/Warsaw", 1}
    };

    public static int Convert(string timeZone)
    {
        return TimeZones.GetValueOrDefault(timeZone);
    }
}