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
        List<List<string>> adatok = File.ReadAllLines("bedat.txt").Select(x => x.Split().ToList()).ToList();
        List<Tanulo> tanulok = File.ReadAllLines("bedat.txt").Select(x => x.Split()).Select(x => new Tanulo(x[0], x[1], int.Parse(x[2])) ).ToList();
        public MainWindow()
        {
            InitializeComponent();

            this.Width = 1200;

            //1.feladat


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
            Button gomb2 = feladat2.Children[0] as Button;
            gomb2.Click += (sender, e) =>
            {
                feladat2fgv(sender, e, feladat2, adatok);
            };
            
            StackPanel feladat3 = feladatKartya(3, 0, 1);
            Button gomb3 = feladat3.Children[0] as Button;
            gomb3.Click += (sender, e) =>
            {
                feladat3fgv(sender, e, feladat3, tanulok);
            };

            StackPanel feladat4 = feladatKartya(4, 0, 2);
            Button gomb4 = feladat4.Children[0] as Button;
            gomb4.Click += (sender, e) =>
            {
                feladat3fgv(sender, e, feladat4, tanulok);
            };
        }

        void feladat2fgv(object sender, RoutedEventArgs e, StackPanel feladat, List<List<string>> adatok)
        {
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
            feladat.Children.Add(szoveg);
            feladat.Children.Add(szoveg2);
        }

        void feladat3fgv(object sender, RoutedEventArgs e, StackPanel feladat, List<Tanulo> adatok)
        {
            var belepes = adatok.Where(x => x.ido > TimeOnly.Parse("7:50") && x.ido <= TimeOnly.Parse("8:15")).ToList();
            var belepesFuzott = belepes.Select(x=> x.idoSzoveg + " "+x.azon);
            Grid belsogrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition()
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition()
                }
            };
            ListBox doboz = new ListBox
            {
                ItemsSource = belepesFuzott,
                Height = 200
            };

            Grid.SetRow(doboz, 0);
            Grid.SetColumn(doboz, 0);
            StackPanel panel = new StackPanel();
            //ADATKÉRÉS
            TextBlock szoveg = new TextBlock
            {
                Text = "Adja meg egy tanuló azonosítóját:",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(25,0,10,10),
                TextAlignment = TextAlignment.Center
            };
            TextBox beker = new TextBox
            {
                Name = "Beker3",
                Width = 100,
                Height = 20,
                Margin = new Thickness(25, 0, 10, 10),
            };
            Button keres = new Button
            {
                Content = "Keresés",
                Width = 50,
                Height = 30,
                Margin = new Thickness(25, 0, 10, 10),
            };
            keres.Click += (sender, e) =>
            {
                var talalt = belepes.Where(x => x.azon == beker.Text).First();
                TextBlock eredmeny = new TextBlock
                {
                    Text = talalt.Szoveg(),
                    HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(25, 0, 10, 10),
                    VerticalAlignment = VerticalAlignment.Top,
                };
                panel.Children.Add(eredmeny);
            };

            Grid.SetRow(panel, 0);
            Grid.SetColumn(panel, 1);

            belsogrid.Children.Add(doboz);
            belsogrid.Children.Add(panel);
            panel.Children.Add(szoveg);
            panel.Children.Add(beker);
            panel.Children.Add(keres);

            feladat.Children.Add(belsogrid);

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

            Button szovegbtn = new Button
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
            stackPanel.Children.Add(szovegbtn);

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