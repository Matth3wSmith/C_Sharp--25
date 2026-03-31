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

namespace kraterek_dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Krater> kraterek;
        public MainWindow()
        {
            InitializeComponent();

            var adatok = File.ReadLines("felszin_tvesszo.txt");
            kraterek = adatok.Select(x =>
            {
                var split = x.Split('\t');
                return new Krater(double.Parse(split[0]), double.Parse(split[1]), double.Parse(split[2]), split[3]);

            }).ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KraterSzam.Text = kraterek.Count+"";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string nev = KraterNev.Text;
            var krater = kraterek.FirstOrDefault(x => x.nev == nev);
            if (krater == null)
            {
                NevShow.Text = "Nincs ilyen nevű kráter!";
            }
            else
            {
                NevShow.Text = krater.Adatok();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var max = kraterek.Max(x => x.r);
            var maxok = kraterek.Where(x => x.r == max);
            Feladat4.ItemsSource = maxok.Select(x => x.Adatok());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var kertnev = Nev.Text;
            Krater krater = kraterek.Where(x => x.nev == kertnev).First();
            Nincskozos.ItemsSource = kraterek.Where(x => x.tavolsag(krater.x, krater.y) > (krater.r + x.r) && x.nev!=krater.nev).Select(x=>x.nev);
            
    
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            List<string> nevek = new List<string>();
            foreach (var item1 in kraterek)
            {
                foreach (var item2 in kraterek)
                {
                    if(item1!=item2 && item1.tavolsag(item2.x,item2.y) < Math.Max(item2.r, item1.r))
                    {

                        if (item1.r > item2.r )
                        {
                            nevek.Add(item1.tartalmaz(item2.nev));
                        }
                        else
                        {
                            nevek.Add(item2.tartalmaz(item1.nev));
                        }
                    }
                }
            }
            Tartalmaz.ItemsSource = nevek;
        }
    }
}