using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace kraterek_dolgozat
{
    internal class Krater
    {
        public double x;
        public double y;
        public double r;
        public string nev;
        public Krater(double x, double y, double r, string nev)
        {
            this.nev = nev;
            this.x = x;
            this.y = y;
            this.r = r;
        }
        public string Adatok()
        {
            //„A(z) Stephen Hawking középpontja X=3.45 Y = 2.78 sugara R = 0.35.
            return $"A(z) {this.nev} középpontja X={this.x} Y = {this.y} sugara R = {this.r}.";
        }

        //Függvény tavolsag(x1, y1, x2, y2 : Valós ) : Valós 
        //tavolsag := Négyzetgyök((x2-x1)*(x2-x1)+(y2-y1)*(y2-y1)) 
        //Függvény vége
        public double tavolsag(double x2, double y2)
        {
            return Math.Sqrt((x2 - this.x) * (x2 - this.x) + (y2 - this.y) * (y2 - this.y));
        }
        public string tartalmaz(string nev)
        {
            return $"A(z) {this.nev} kráter tartalmazza a(z) {nev} krátert.";
        }
    }
}
