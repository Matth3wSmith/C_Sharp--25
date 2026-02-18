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
        List<List<string>> adatok;
        public MainWindow()
        {
            InitializeComponent();

            this.Width = 1200;

            //1.feladat
            List<List<string>> adatok = File.ReadAllLines("bedat.txt").Select(x=>x.Split().ToList()).ToList();


            gridTablazat(FoGrid, FoGridOszlop, FoGridSor);
            /*feladatKartya(3,0,0);
            feladatKartya(3,1,0);
            feladatKartya(3,2,0); 
            feladatKartya(3, 0, 1);
            feladatKartya(3, 1, 1);
            feladatKartya(3, 2, 1); 
            feladatKartya(3, 0, 2);
            feladatKartya(3, 1, 2);
            feladatKartya(3, 2, 2);*/


            StackPanel feladat2 = feladatKartya(2, 0, 0);
            var belepes = adatok.Where(x => x[2] == "1").First();
            var kilepes = adatok.Where(x => x[2] == "2").Last();
            Label szoveg = new Label
            {
                Content = $"Az első tanuló {belepes[1]}-kor lépett be a főkapun.",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            Label szoveg2 = new Label
            {
                Content = $"Az utolsó tanuló {kilepes[1]}-kor lépett ki a főkapun.",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            feladat2.Children.Add(szoveg);
            feladat2.Children.Add(szoveg2);

        }

        StackPanel feladatKartya(int feladatSzam, int pozicioSor, int pozicioOszlop)
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
                
            };
            StackPanel stackPanel = new StackPanel
            {
                Name = "Feladat" + feladatSzam,
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            Button szoveg = new Button
            {

                Content = feladatSzam+". feladat",
                Padding = new Thickness(10),
                Margin = new Thickness(0, 10, 0, 10),
                
                FontSize = 20,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };

            Grid.SetRow(kulsoKeret, pozicioSor);
            Grid.SetColumn(kulsoKeret, pozicioOszlop);

            kulsoKeret.Child = belsoKeret;
            belsoKeret.Child = belsoGrid;
            belsoGrid.Children.Add(stackPanel);
            stackPanel.Children.Add(szoveg);

            FoGrid.Children.Add(kulsoKeret);
            return stackPanel;
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