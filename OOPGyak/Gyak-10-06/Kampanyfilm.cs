using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyak_10_06
{
    internal class Kampanyfilm:Video
    {
        public override void mutat()
        {
            Console.WriteLine("Ádám rendezői változat elindult");
        }

        public override string ToString()
        {
            return "Kampányfilmhez kapcsolódó dolgok osztálya";
        }
    }
}
