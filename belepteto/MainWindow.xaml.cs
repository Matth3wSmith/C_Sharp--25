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
        int FoGridSor = 3;
        int FoGridOszlop = 3;
        public MainWindow()
        {
            InitializeComponent();

            //1.feladat
            //List<List<string>> adatok = File.ReadAllLines("beadat.txt").Select(x=>x.Split().ToList()).ToList();

            gridTablazat(FoGrid, FoGridOszlop, FoGridSor);
            feladatKartya(3,1,2);
        }

        void feladatKartya(int feladatSzam, int pozicioSor, int poziciosOszlop)
        {
            //Keret
            Border kulsoKeret = new Border
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
                        new GradientStop((Color)ColorConverter.ConvertFromString("#FF320A8E"),0),
                        new GradientStop(Colors.Orange, 0.5),
                        new GradientStop(Colors.Yellow, 1)
                    }
                }
            };

            Border belsoKeret = new Border
            {
                BorderThickness = new Thickness(1),
                BorderBrush = Brushes.Black,
            };
            Grid belsoGrid = new Grid
            {
                Name = "Feladat"+ feladatSzam,
            };
            Label szoveg = new Label
            {
                Content = feladatSzam+". feladat",
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };

            Grid.SetRow(kulsoKeret, pozicioSor);
            Grid.SetColumn(kulsoKeret, poziciosOszlop);

            kulsoKeret.Child = belsoKeret;
            belsoKeret.Child = belsoGrid;
            belsoGrid.Children.Add(szoveg);
            
            FoGrid.Children.Add(kulsoKeret);
        }


        void gridTablazat(Grid GridNev, int oszlop, int sor)
        {
            for(int i = 0; i < oszlop;  i++)
            {
                ColumnDefinition ujOszlop = new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star)
                };
                GridNev.ColumnDefinitions.Add(ujOszlop);
            }
            for(int k = 0; k < sor; k++)
            {
                RowDefinition ujSor = new RowDefinition()
                {
                    Height = GridLength.Auto
                };
                GridNev.RowDefinitions.Add(ujSor);
            }
        }
    }
}