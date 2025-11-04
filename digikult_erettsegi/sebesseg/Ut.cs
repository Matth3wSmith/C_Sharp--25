using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sebesseg
{
    internal class Ut
    {
        public int km;
        public string jelzes;
        public int  sebesseg;
        public bool varosbanVan;
        public Ut(string sor)
        {
            string[] adatok = sor.Split(' ');
            this.km = int.Parse(adatok[0]);
            this.jelzes = adatok[1];

        }
        public Ut(int ut,string jelzes)
        {
            this.km = ut;
            this.jelzes = jelzes;

            try
            {
                sebesseg = int.Parse(jelzes);
            }
            catch (Exception)
            {

                if (varosbanVan)
                {
                    if (jelzes == "%" || jelzes == "#")
                    {
                        sebesseg = 50;
                    }
                    else { 
                        sebesseg = int.Parse(jelzes);
                    }

                }
                else
                {
                    if (jelzes == "%" || jelzes == "#" || jelzes == "]")
                    {
                        sebesseg = 90;
                    }
                    else
                    {
                        sebesseg = int.Parse(jelzes);
                    }
                }
            }
            

        }
        public bool isTelepules()
        {
            return this.jelzes.Length >= 4;
        }
        
        public override string ToString()
        {
            return $"{km} {jelzes} {varosbanVan}";
        }
    }
}
