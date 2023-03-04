class GeoInfo
{
    public string geonameid;
    public string name;
    public string asciiname;
    public string latitude;
    public string longitude;
    public string feature_class;
    public string feature_code;
    public string country_code;
    public string cc2;
    public string admin1_code;
    public string admin2_code;
    public string admin3_code;
    public string admin4_code;
    public string population;
    public string elevation;
    public string dem;
    public string timezone;
    public string modification_date;
    public GeoInfo(params string[] subs)
        {
        geonameid = subs[0];
        name = subs[1];
        asciiname = subs[2];
        latitude = subs[3];
        longitude = subs[4];
        feature_class = subs[5];
        feature_code = subs[6];
        country_code = subs[7];
        cc2 = subs[8];
        admin1_code = subs[9];
        admin2_code = subs[10];
        admin3_code = subs[11];
        population = subs[12];
        elevation = subs[13];
        dem = subs[14];
        timezone = subs[15];
        modification_date = subs[16];
        }
    public void Print()
    {
        Console.WriteLine($"{geonameid}\t{name}\t{asciiname}\t{latitude}\t{longitude}");
    }
}