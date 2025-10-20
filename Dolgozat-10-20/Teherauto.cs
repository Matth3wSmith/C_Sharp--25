using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat_10_20
{
    internal abstract class Teherauto:IGepjarmu
    {
        protected string tipus;
        protected string altipus;
        protected double tomeg;
        protected bool terepes;
        protected int kerekszam;
        protected Teherauto(bool terepes) {
            this.tipus = "Teherautó";
            this.terepes = terepes;
        }
        public string Tipus
        {
            get { return tipus; }
        }
        public double Tomeg
        {
            get { return tomeg; }
            set { tomeg = value; }
        }

        public abstract int Kerekszam
        {
            set;
        }
        public abstract string Altipus
        {
            set;
        }

    }
}
