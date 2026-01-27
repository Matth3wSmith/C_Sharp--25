using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace regexp_gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var adathalmaz = File.ReadAllText("shakespeare.txt");
            Regex regex = new Regex(@"^[A-Z]+\b");

            Console.WriteLine(regex.Matches(adathalmaz).Count);
        }
    }
}
