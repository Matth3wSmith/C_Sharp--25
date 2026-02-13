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

namespace belepteto
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
            List<List<string>> adatok = File.ReadAllLines("beadat.txt").Select(x=>x.Split().ToList()).ToList();
            

        }

        void feladatKartya()
        {
            //Keret
            Border keret = new Border
            {
                BorderThickness = new Thickness(10),
                CornerRadius = new CornerRadius(5),
                //Margin = new Thickness(69, 75, 565, 200),
                BorderBrush = new LinearGradientBrush
                {
                    EndPoint = new Point(0.5, 1),
                    StartPoint = new Point(0.5, 0),
                    GradientStops = new GradientStopCollection
                    {
                        new GradientStop((Color)ColorConverter.ConvertFromString("#FF320A8E")),
                        new GradientStop(Colors.Orange, 0.5),
                        new GradientStop(Colors.Yellow, 1)
                    }

                }
            };

        }

    }
}