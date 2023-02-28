StreamReader sr = new StreamReader("D:\\Lessons\\RU\\Example.txt");
List<GeoInfo> result = new List<GeoInfo>();

string line = sr.ReadLine();
while (line != null)
{
    string[] subs = line.Split('\t');
    GeoInfo city = new GeoInfo(subs);
    result.Add(city);
    line = sr.ReadLine();
}

sr.Close();

/*foreach (var s in result)
{
    Console.WriteLine(s);
    //s.Print();
}*/