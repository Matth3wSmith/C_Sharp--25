using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OOPGyak_10_14
{
    internal class Monitor
    {
        public string felbontas;
        public double atlo;

        public Monitor(string felbontas)
        {
            this.felbontas = felbontas;
        }

        public Monitor(string felbontas, double atlo)
        {
            this.felbontas = felbontas;
            this.atlo = atlo;
        }

        ///<summary>
        ///Method <c>Monitor<c> Cigányok vqafgyk
        ///</summary>
        public Monitor(int szelsseg, int magassag, double atlo)
        {
            this.felbontas = szelsseg + "x" + magassag;
            this.atlo = atlo;
        }
    }
}
