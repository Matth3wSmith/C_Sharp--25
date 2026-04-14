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
        List<Rekesz> rekeszek = new List<Rekesz>();
        int szalagHossz;
        int szalagSzelesseg;
        public MainWindow()
        {
            InitializeComponent();

            //1. feladat Fájlbeolvasás
            var adatok = File.ReadAllLines("szallit.txt", Encoding.UTF8);
            int szalagHossz = int.Parse(adatok[0].Split(" ")[0]);
            int szalagSzelesseg = int.Parse(adatok[0].Split(" ")[1]);
            for(int i = 1; i < adatok.Length; i++)
            {
                var split = adatok[i].Split(" ");
                rekeszek.Add(new Rekesz(i + 1, int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]), szalagHossz));
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int sorszam = int.Parse(F2.Text);
            
            
            Valasz.Text = "Honnan: " + rekeszek[sorszam - 1].kezd +" ; Hova: "+rekeszek[sorszam-1].veg;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int maxHossz = rekeszek.Max(x => x.hossz);
            Max.Text += (' '+maxHossz);
            Maxok.Text += ' '+ string.Join(" ", rekeszek.Where(x => x.hossz == maxHossz).Select(x => x.sorszam));
        }
    }
}