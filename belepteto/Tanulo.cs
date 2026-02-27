using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belepteto
{
    class Tanulo
    {
        public int kod;
        public string idoSzoveg;
        public TimeOnly ido;
        public string azon;
        public Tanulo(string azon, string ido, int kod)
        {
            this.kod = kod;
            this.idoSzoveg = ido;
            this.azon = azon;
            this.ido = TimeOnly.Parse(ido);
        }

        public string Szoveg()
        {
            return this.azon + " " + this.idoSzoveg + " " + this.kod;
        }


    }
}
