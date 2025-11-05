using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sebesseg
{
    internal class Ut
    {
        public int m;
        public string jelzes;
        public int  sebesseg;
        private  bool varosbanVan;
        public bool VarosbanVan
        {
            get { return varosbanVan; }
            set
            {
                if (value)
                {
                    if (jelzes == "%" || jelzes == "#" || isTelepules())
                    {
                        sebesseg = 50;
                    }
                    else
                    {
                        sebesseg = Convert.ToInt32(jelzes);
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
                        sebesseg = Convert.ToInt32(jelzes);
                    }
                }
                varosbanVan = value;
            }
        }
        public Ut(string sor)
        {
            string[] adatok = sor.Split(' ');
            this.m = int.Parse(adatok[0]);
            this.jelzes = adatok[1];

        }
        public Ut(int ut,string jelzes)
        {
            this.m = ut;
            this.jelzes = jelzes;
        }
            

        
        public bool isTelepules()
        {
            return this.jelzes.Length >= 4;
        }
        
        public override string ToString()
        {
            return $"{m} {jelzes} {varosbanVan} {sebesseg}";
        }
    }
}
