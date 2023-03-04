using System.Reflection;

class Infoservice
{
    public List<GeoInfo> list;
    public string iden;
    public int count_on_page;
    public int page_number;
    public Infoservice(int number1, int number2, string iden, List<GeoInfo> list)
    { 
        this.list = list;
        this.iden = iden;
        count_on_page = number1;
        page_number = number2;
    }

    public void First()
    {
        foreach (var s in list) 
        {
            GeoInfo x = s;
            Type fieldsType = typeof(GeoInfo);
            FieldInfo[] fields = fieldsType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            string a = Convert.ToString(fields[0].GetValue(x));
            var b = fields[1].GetValue(x);
            if (a == iden)
            {
                Console.WriteLine($"{b}");
                break;
            }
        }
    }

    public void Second()
    {
        int summ = list.Count / count_on_page;
        int t = count_on_page * page_number;
        if (page_number <= summ)
        {
            for (int i = t - count_on_page - 1; i < t; i++)
            {
                GeoInfo arr = list[i];
                Type fieldsType = typeof(GeoInfo);
                FieldInfo[] f = fieldsType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                for (int j = 0; j < f.Length; j++)
                {
                    Console.Write($"{f[j].GetValue(arr)}\t");
                }
            }
        }

    }
}