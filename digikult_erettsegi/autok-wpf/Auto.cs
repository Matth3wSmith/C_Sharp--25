using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autok_wpf
{
    internal class Auto
    {
        public string rendszam;
        public int ora;
        public int perc;
        public int sebesseg;
        public TimeOnly idopont;
        //az autó rendszáma, a jeladás idejének óra, illetve perc értéke, valamint a jeladáskor mért sebesség km / h mértékegységbe
        public Auto(string rendszam, int ora, int perc, int sebesseg) {
            this.rendszam = rendszam;
            this.ora= ora;
            this.perc = perc;
            this.sebesseg = sebesseg;
            this.idopont = new TimeOnly(ora, perc);
        }

        public string RendszamNelkul()
        {
            return "Mérés időpontja: "+ this.idopont.ToString() + ", Sebessége: " + this.sebesseg+ " km/h";
        }
    }
}
