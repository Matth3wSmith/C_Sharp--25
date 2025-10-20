using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat_10_20
{
    internal interface IGepjarmu
    {
        
        string Tipus
        {
            get;
        }
        double Tomeg
        {
            get;
            set;
        }
        void Indul()
        {
            Console.WriteLine("A jármű elindult.");
            Console.WriteLine("Vututututuu");
        }

    }
}
