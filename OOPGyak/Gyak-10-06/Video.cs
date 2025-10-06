using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gyak_10_06
{
    abstract internal class Video:Interface1
    {

        protected Video()
        {

        }

        public string Tipus
        {
            get 
            {
                    return "video";
            }
        }

        abstract public void mutat();
    }
}
