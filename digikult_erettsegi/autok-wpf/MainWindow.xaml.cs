using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace autok_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        List<Auto> osszAdat = new List<Auto>();
        Dictionary<string, List<Auto>> autok = new Dictionary<string, List<Auto>>();
        //2. feladat változója
        TimeOnly utolsoIdopont;
        TimeOnly kezdoIdopont;
        public MainWindow()
        {
            InitializeComponent();

            //1.feladat
            var adatok = File.ReadLines("jeladas.txt");

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
        //2. feladat
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Utolsó jeladás időpontja
            TimeOnly utolso = osszAdat[osszAdat.Count - 1].idopont;
            Rendszam.Text += " " +osszAdat[osszAdat.Count - 1].rendszam;
            utolsoIdopont = utolso;
            kezdoIdopont = new TimeOnly(0,0,0);
            timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromMilliseconds(0.5);

            timer.Tick += Timer_Tick;   

            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (utolsoIdopont == kezdoIdopont)
            {
                timer.Stop();
                timer.Tick -= Timer_Tick;
            }
            Clock.Text = kezdoIdopont.ToString("HH:mm:ss");
            kezdoIdopont = kezdoIdopont.Add(TimeSpan.FromSeconds(1));
            
        }

        protected override void OnClosed(EventArgs e)
        {
            timer.Stop();
            timer.Tick -= Timer_Tick;
            base.OnClosed(e);
        }

        private void Feladat_3(object sender, RoutedEventArgs e)
        {
            var elsoAutoAdat = autok[osszAdat[0].rendszam];
            RendszamLista.ItemsSource = elsoAutoAdat.Select(x => x.RendszamNelkul());
            Rendszam3.Text = elsoAutoAdat[0].rendszam;
        }
    }
}