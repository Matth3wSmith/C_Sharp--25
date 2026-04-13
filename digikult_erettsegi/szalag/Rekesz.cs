using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szalag
{
    internal class Rekesz
    {
        public int ido;
        public int kezd;
        public int veg;
        public int tomeg;
        public int hossz;
        public int szalagHossz;
        public int sorszam;
        public Rekesz(int sorszam, int ido, int kezd, int veg, int tomeg, int szalagHossz)
        {
            this.sorszam = sorszam;
            this.ido = ido;
            this.kezd = kezd;
            this.veg = veg;
            this.tomeg = tomeg;
            this.szalagHossz = szalagHossz;
            if (kezd > veg)
            {
                this.hossz = veg - kezd;
            }
            else
            {
                this.hossz = szalagHossz - kezd + veg;
            }
        }
    }
}
