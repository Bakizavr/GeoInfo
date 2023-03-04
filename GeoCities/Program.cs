List<GeoInfo> result = new List<GeoInfo>();
foreach (var line in File.ReadLines("D:\\Lessons\\RU\\Example.txt"))
{
    string[] subs = line.Split('\t');
    GeoInfo city = new GeoInfo(subs);
    result.Add(city);
}
//проверка
/*foreach (var s in result)
{
    s.Print();
}*/

//кол-во городов на странице
int y = 4;
//номер страницы
int z = 2;
string id = "451749";
Infoservice mass = new Infoservice(y, z, id, result);
mass.First();
mass.Second();