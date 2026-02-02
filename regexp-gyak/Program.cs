using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace regexp_gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var adathalmaz = File.ReadAllText("shakespeare.txt");
            Regex regex = new Regex(@"[A-ZÉÁŐÚŰÖÜÓÍ-]{2,}\s[A-ZÉÁŐÚŰÖÜÓÍ-]{2,}\s|[A-ZÉÁŐÚŰÖÜÓÍ-]{2,}\b");

            foreach (var item in regex.Matches(adathalmaz))
            {
                Console.WriteLine(item);
            }

            Regex romeoNev = new Regex(@"romeo", RegexOptions.IgnoreCase);
            Console.WriteLine("Romeo név: " + romeoNev.Matches(adathalmaz).Count);


            Regex regozva = new Regex(@"\bromeo[A-ZÉÁŰÚŐÓÜÖÍ]", RegexOptions.IgnoreCase);
            Console.WriteLine("Rómeó ragozva: "+regozva.Matches(adathalmaz).Count);

            Regex juliaRag = new Regex(@"\bjulia[A-ZÉÁŰÚŐÓÜÖÍ]", RegexOptions.IgnoreCase);
            Console.WriteLine("Júlia ragozva: " + juliaRag.Matches(adathalmaz).Count);

            //van-e benne szám, ha van, van évszám is?
            Regex szam = new Regex(@"[0-9]+");
            Console.WriteLine("Szám: "+ szam.Matches(adathalmaz).Count);

            Regex evszam = new Regex(@"[0-9]{4}");
            Console.WriteLine("Szám: " + evszam.Matches(adathalmaz).Count);

            //Azok a szavak, amik az ELSŐ ŐR első szavai
            Regex elsoOr = new Regex(@"ELSŐ ŐR\t([A-ZÉÁŰÚŐÓÜÖÍ]+)\s([A-ZÉÁŰÚŐÓÜÖÍ]+)\s([A-ZÉÁŰÚŐÓÜÖÍ]+)\s([A-ZÉÁŰÚŐÓÜÖÍ]+)", RegexOptions.IgnoreCase);
            foreach (var item in elsoOr.Match(adathalmaz).Groups)
            {
                Console.WriteLine("Első őr első szavai: " + item);
            }

            Regex nevesOr = new Regex(@"ELSŐ ŐR\t(?<elso>[A-ZÉÁŰÚŐÓÜÖÍ]+)\s(?<masodik>[A-ZÉÁŰÚŐÓÜÖÍ]+)>\s(?<harmadik>[A-ZÉÁŰÚŐÓÜÖÍ]+)\s(?<negyedik>[A-ZÉÁŰÚŐÓÜÖÍ]+)", RegexOptions.IgnoreCase);
            var valami = elsoOr.Match(adathalmaz);
            Console.WriteLine(valami);
            foreach (var item in elsoOr.Match(adathalmaz).Groups)
            {
                Console.WriteLine("Első őr első szavai: " + item);
            }

        }
    }
}
