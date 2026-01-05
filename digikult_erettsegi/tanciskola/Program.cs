namespace tanciskola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.feladat
            var adatok = File.ReadAllLines("tancrend.txt").Chunk(3);
            List<Tancpar> tancosok = adatok.Select(x => new Tancpar(x[0],x[1], x[2])).ToList();

            //2.feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine("Első tánc: "+tancosok.First().tancnem);
            Console.WriteLine("Utolsó tánc: " + tancosok.Last().tancnem);

            //3.feladat
            Console.WriteLine("3. feladat");
            Console.WriteLine(tancosok.Count(x=>x.tancnem=="samba")+" pár mutatta be a sambát.");

            //4. feladat
            Console.WriteLine("4. feladat");
            Console.WriteLine("Vilma ezekben a táncokban szerepelt: "+ String.Join(", ",tancosok.Where(x=>x.lany=="Vilma").Select(x=>x.tancnem).Distinct()));

            //5.feladat
            Console.WriteLine("5. feladat");
            Console.Write("Kérek egy táncnemet: ");
            string tancnem = Console.ReadLine();
            var vilmapar = tancosok.Where(x => x.tancnem == tancnem && x.lany == "Vilma");
            if (vilmapar.Count() == 0)
            {
                Console.WriteLine("Vilma nem táncolt samba-t.");
            }
            else {
                Console.WriteLine("A {0} bemutatóján Vilma párja {1} volt.", tancnem,vilmapar.First().fiu);
            }

            //6.feladat
            StreamWriter sw = new StreamWriter("szereplok.txt");

            var lanyok = String.Join(", ",tancosok.Select(x => x.lany).Distinct());
            var fiuk = String.Join(", ",tancosok.Select(x => x.fiu).Distinct());
            sw.WriteLine("Lányok: "+lanyok);
            sw.WriteLine("Fiúk: " + fiuk);
            sw.Close();

            //7.feladat
            Console.WriteLine("7.feladat");
            var legtobbFiu = tancosok.GroupBy(x => x.fiu).Select(x=> new { nev=x.Key, eloford = x.Count() }).OrderByDescending(x => x.eloford);
            Console.WriteLine("Legtöbbször szerepelt fiúk: "+String.Join(", ", legtobbFiu.TakeWhile(x=>x.eloford==legtobbFiu.Max(x=>x.eloford)).Select(x=>x.nev)));
            var legtobbLany= tancosok.GroupBy(x => x.lany).Select(x => new { nev = x.Key, eloford = x.Count() }).OrderByDescending(x => x.eloford);
            Console.WriteLine("Legtöbbször szerepelt lányok: " + String.Join(", ", legtobbLany.TakeWhile(x => x.eloford == legtobbLany.Max(x => x.eloford)).Select(x => x.nev)));
        }
    }
}
