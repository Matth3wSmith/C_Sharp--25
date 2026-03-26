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

namespace autok_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //1.feladat
            var adatok = File.ReadLines("jeladas.txt");
            List<Auto> osszAdat = new List<Auto>();
            Dictionary<string, List<Auto>> autok = new Dictionary<string, List<Auto>>();

            foreach (var adat in adatok)
            {
                var split = adat.Split('\t');
                Auto auto = new Auto(split[0], int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]));
                osszAdat.Add(auto);
                if (autok.Keys.Contains(split[0]))
                {
                    autok[split[0]].Add(auto);
                }
                else
                {
                    autok.Add(split[0], new List<Auto>() { auto });
                }
            }

        }
    }
}