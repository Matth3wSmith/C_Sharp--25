namespace Dolgozat_10_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DarusAuto d1 = new DarusAuto(true, "Volvo", "Piros", "ABC-123");
            DarusAuto d2 = new DarusAuto(false, "Scania", "Kék", "XYZ-789");
            DarusAuto d3 = new DarusAuto(true, "Suzuki", "Zöld", "LMN-456");

            Console.WriteLine( d1.ToString());
            Console.WriteLine(d2.ToString());
            Console.WriteLine(d3.ToString());

        }
    }
}
