using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace szalag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //1. feladat Fájlbeolvasás
            var adatok = File.ReadAllLines("szallit.txt", Encoding.UTF8);
            int szalagHossz = int.Parse(adatok[0].Split(" ")[0]);
            int szalagSzelesseg = int.Parse(adatok[0].Split(" ")[1]);
            List<Rekesz> rekeszek = new List<Rekesz>();
            for(int i = 1; i < adatok.Length; i++)
            {
                var split = adatok[i].Split(" ");
                rekeszek.Add(new Rekesz(i + 1, int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]), szalagHossz));
            }


        }
    }
}