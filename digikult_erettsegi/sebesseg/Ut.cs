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
        }
    }
}
