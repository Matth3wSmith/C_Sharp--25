using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace belepteto
{
    class Tanulo
    {

        public string idoSzoveg;
        public TimeOnly ido;
        public string azon;
        public int kod;
        public Tanulo(string azon, string ido, int kod)
        {
            this.azon = azon;
            this.idoSzoveg = ido;
            this.ido = TimeOnly.Parse(ido);
            this.kod = kod;
        }
        public string Szoveg()
        {
            return $"Azonosító: {azon};\nIdő: {idoSzoveg};\nTevékenység: {kod}";
        }

    }
}
