using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operatorok_gyak
{
    internal class EgyObj
    {
        public string szoveg;
        public EgyObj(string szoveg)
        {
            this.szoveg = szoveg;
        }
        public static EgyObj operator +(EgyObj obj1, string szoveg)
        {
            return new EgyObj(obj1.szoveg+"\n"+szoveg);
        }
        public static EgyObj operator -(EgyObj obj1, string szoveg)
        {
            Console.WriteLine(obj1.szoveg.Except(szoveg));
            Console.WriteLine(obj1.szoveg);
            return obj1;
        }

    }
}
