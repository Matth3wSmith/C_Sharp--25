using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanciskola
{
    internal class Tancpar
    {

        public string fiu;
        public string lany;

        public string tancnem;
        public Tancpar( string tancnem,string lany, string fiu)
        {
            this.tancnem= tancnem;
            this.fiu= fiu;
            this.lany= lany;
        }
    }
}
