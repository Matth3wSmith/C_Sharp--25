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

                string[] vag = olvas.ReadLine().Split(' ');

                utak.Add(new Ut(int.Parse(vag[0]), vag[1] ));
            }

            olvas.Close();

            //2. feladat
            Console.WriteLine("2. feladat");
            Console.WriteLine("A települések neve:");
            Console.WriteLine(String.Join("\n", utak.Where(x=>x.isTelepules()).Select(x=>x.jelzes)));

            //3. feladat
            Console.WriteLine("3. feladat");
            Console.Write("adja meg a vizsgált szakasz hosszát km-ben! ");
            double hosszM = Convert.ToDouble(Console.ReadLine()) * 1000;
            int minseb = 90;

            //Városban vagyunk-e
            bool tempVarosban = false; 

            for (int i = 0; i < utak.Count; i++) 
            { 
                tempVarosban = utak[i].isTelepules() || (tempVarosban && utak[i].jelzes!="]");
                utak[i].VarosbanVan = tempVarosban;

            }
            //###################################


            for (int i = 0; i < utak.Count; i++)
            {
                if (utak[i].m < hosszM)
                {
                    //Console.WriteLine(utak[i].ToString());

                    if (utak[i].sebesseg < minseb)
                    {
                        minseb = utak[i].sebesseg;
                    }

                }
            }
            Console.WriteLine("Az első {0} km-en {1} km/h volt a legalacsonyabb megengedett sebesség.",hosszM/1000,minseb);

            //4. feladat
            List<Ut> tUt = utak.Where(x => x.isTelepules() || x.jelzes == "]").ToList();
            double tUtSum = 0;
            for (int i = 0; i < tUt.Count; i+=2)
            {
                Console.WriteLine(tUtSum);
                tUtSum += tUt[i + 1].m - tUt[i].m;
            }
            Console.WriteLine("4. feladat");
            Console.WriteLine("Az út {0:0.00} százaléka vezet településen belül.", (tUtSum/osszUt*100) );

            //5. feladat
            Console.WriteLine("5. feladat");
            Console.Write("Adja meg egy település nevét! ");
            string varosNev = Console.ReadLine();
            Ut varos = utak.Where(x => x.jelzes == varosNev).First();
            bool varosban = false;
            Ut varosKezd = utak[0];
            Ut varosVeg = utak[0]; 
            int korlatozas = 0;
            for (int i = 0; i < utak.Count; i++)
            {
                if (utak[i] == varos)
                {
                    varosKezd = utak[i];
                    varosban = true;
                }
                else if (varosban)
                {
                    if (utak[i].jelzes.Length == 2)
                    {
                        korlatozas++;
                    }
                    else if (utak[i].jelzes == "]")
                    {
                        varosVeg = utak[i];
                        varosban = false;
                    }
                }
            }
            Console.WriteLine("A sebességkorlátozó táblák száma: "+korlatozas);
            Console.WriteLine("Az út hossza a településen belül {0} méter.",varosVeg.m-varosKezd.m);

            //6. feladat
            Console.WriteLine("6. feladat");
            Ut elotteUt = utak[0];
            Ut elotteVaros = utak[0];
            Ut utanaVaros = utak[0];

            //Előtte lévő város
            for (int i = utak.IndexOf(varosKezd)-1; i>0; i--)
            {
                if (utak[i].jelzes == "]")
                {
                    elotteUt = utak[i];
                }
                else if (utak[i].isTelepules())
                {
                    elotteVaros = utak[i];
                    break;
                }
            }
            //Utánaváros
            for (int i = utak.IndexOf(varosKezd)+1; i < utak.Count; i++)
            {
                if (utak[i].isTelepules())
                {
                    utanaVaros = utak[i];
                    break;
                }
            }
            //Előtte lévő város közelebb van
            if (varosKezd.m - elotteUt.m <= utanaVaros.m - varosVeg.m)
            {
                Console.WriteLine("A legközelebbi település: "+elotteVaros.jelzes);

            }
            else
            {

                Console.WriteLine("A legközelebbi település: " + utanaVaros.jelzes);
            }
        }
    }
}
