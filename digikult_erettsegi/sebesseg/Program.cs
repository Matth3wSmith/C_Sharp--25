namespace sebesseg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ut> utak = new List<Ut>();
            StreamReader olvas = new StreamReader("ut.txt");
            int osszUt = int.Parse(olvas.ReadLine());
            while (!olvas.EndOfStream)
            {
                utak.Add(new Ut(olvas.ReadLine()));
            }

            olvas.Close();  

        }
    }
}
