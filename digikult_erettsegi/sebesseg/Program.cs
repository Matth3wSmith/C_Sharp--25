namespace sebesseg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. feladat
            List<Ut> utak = new List<Ut>();
            StreamReader olvas = new StreamReader("ut.txt");
            int osszUt = int.Parse(olvas.ReadLine());
            while (!olvas.EndOfStream)
            {
                utak.Add(new Ut(olvas.ReadLine()));
            }

            olvas.Close();

            //2. feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine("A települések neve:");
            Console.WriteLine(String.Join("\n", utak.Where(x=>x.isTelepules()).Select(x=>x.jelzes)));

            //3. feladat
            Console.WriteLine("3. feladat");
            Console.Write("adja meg a vizsgált szakasz hosszát km-ben! ");
            double hosszkm = Convert.ToDouble(Console.ReadLine());
            int minseb = 130;
            bool tempVarosban = false; 

            for (int i = 0; i < utak.Count; i++) 
            { 
                tempVarosban = utak[i].isTelepules() || (tempVarosban && utak[i].jelzes!="]");
                utak[i].varosbanVan = tempVarosban;

            }

            for (int i = 0; i < utak.Count; i++)
            {
                if (utak[i].km < hosszkm)
                {
                    if (utak[i].sebesseg < minseb)
                    {
                        minseb = utak[i].sebesseg;
                    }
                }
            }
            Console.WriteLine("Az első {0} km-en {1} km/h volt a legalacsonyabb megengedett sebesség.",hosszkm,minseb);
        }
    }
}
