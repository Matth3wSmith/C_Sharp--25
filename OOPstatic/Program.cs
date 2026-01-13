using System.Security.Cryptography;

namespace OOPstatic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Proba proba = new Proba();
            //Példánynak nincs statikus függvénye, csak az osztályra hivatkozva lehet elérni
            proba.fv2();
            //Statikus függvényt az osztály nevével lehet elérni
            Proba.fv1();

            Console.WriteLine(Proba.egyik);
        }
    }
}
