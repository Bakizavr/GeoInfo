using System.Text;

namespace GeoInfo.Models
{
    public class CityName
    {
        private const string Cyrillic = "AaБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя";
        private const string Latin = "A|a|B|b|V|v|G|g|D|d|E|e|Ё|ё|Zh|zh|Z|z|I|i|I|i|K|k|L|l|M|m|N|n|O|o|||||||||||||||||||||||||";
        private Dictionary<char, string> Alphabet;

        private void ConverterChars()
        {
            var replace = Latin.Split('|');
            for (int ix = 0; ix < Cyrillic.Length; ++ix)
            {
                Alphabet.Add(Cyrillic[ix], replace[ix]);
            }
        }
        public string Romanize(string russian)
        {
            var buf = new StringBuilder(russian.Length);
            foreach (char ch in russian)
            {
                if (Alphabet.ContainsKey(ch)) buf.Append(Alphabet[ch]);
                else buf.Append(ch);
            }
            return buf.ToString();
        }
    }
}
