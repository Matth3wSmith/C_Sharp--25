using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOPstatic
{
    internal class Proba
    {
        public static string egyik = "Egyik mező";

        public static void fv1()
        {
            Console.WriteLine("Én egy statikus függvény vagyok.");
            Console.WriteLine();
        }
        public void fv2()
        {
            Console.WriteLine("Én egy dinamikus függvény vagyok.");
            Console.WriteLine(egyik);
        }

    }
}
