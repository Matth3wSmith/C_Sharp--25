namespace operatorok_gyak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EgyObj szoveg1 = new EgyObj("Ez egy jó mondat.");
            Console.WriteLine((szoveg1 + "Ez egy másik jó mondat.").szoveg);
            Console.WriteLine((szoveg1 - "aaa").szoveg);


        }
    }
}
