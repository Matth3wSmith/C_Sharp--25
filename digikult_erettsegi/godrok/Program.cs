

using System;

namespace godrok
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //1. feladat
            List<int> adatok = (File.ReadAllLines("melyseg.txt")).Select(x => Convert.ToInt32(x)).ToList();
            List<int> adatindexek = adatok.Select((x,i)=>i).ToList();    
            Console.WriteLine("1. feladat");
            Console.WriteLine("A fájl adatainak száma: "+adatok.Count);

            //2. feladat
            Console.WriteLine("2. feladat");
            Console.Write("Adjon meg egy távolságértéket! ");
            int tavolsag = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Ezen a helyen a felszín {adatok[tavolsag-1]} méter mélyen van.");

            //3. feladat
            Console.WriteLine("3. feladat");
            Console.WriteLine("Az érintetlen terület aránya: {0:0.00}%",  adatok.Where(x=> x== 0).Count()/ Convert.ToDouble(adatok.Count) * 100 );

            //4. feladat
            StreamWriter ir = new StreamWriter("godrok.txt");
            for (int i = 0; i < adatok.Count-1; i++)
            {
                if (adatok[i] != 0)
                {
                    ir.Write(adatok[i]+" ");
                    if (adatok[i + 1] == 0)
                    {
                        ir.WriteLine();
                    }
                }
            }
            ir.Close();

            //5.feladat
            Console.WriteLine("5. feladat");
            Console.WriteLine("A gödrök száma: "+File.ReadAllLines("godrok.txt").Length);

            //6. feladat
            Console.WriteLine("6. feladat");

            if(tavolsag>adatok.Count || tavolsag < 1)
            {
                Console.WriteLine("Az adott helyen nincs gödör");
            }
            else
            {
                Console.WriteLine("a)");
                int kezdo = 0;
                for(int i = 0; i < tavolsag - 1; i++)
                {
                    if (adatok[i]>0 && kezdo == 0)
                    {
                        kezdo = i;
                    }
                    else if (adatok[i] == 0)
                    {
                        kezdo = 0;
                    }
                }
            }

        }
    }
}
