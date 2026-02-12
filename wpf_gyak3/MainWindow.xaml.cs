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

namespace wpf_gyak3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int row = 10;
        int column = 10;
        public MainWindow()
        {
            InitializeComponent();
            this.Left = 300;
            this.Top = 100;
            //Grid táblázat létrehozása
            for (int i = 0; i < row; i++)
            {
                RowDefinition ujSor = new RowDefinition
                {
                    Height = GridLength.Auto
                };
                TableGrid.RowDefinitions.Add(ujSor);

            }
            for (int i = 0; i < row; i++)
            {
                ColumnDefinition ujOszlop = new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                };

                TableGrid.ColumnDefinitions.Add(ujOszlop);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Random rand = new Random();
            //string szoveg = Szoveg.Text;
            int randCol = rand.Next(0, column);
            int randRow = rand.Next(0, row);
            Label label = new Label();
            label.Content = " s: " + randRow + " o: " + randCol;
            Grid.SetColumn(label, randCol);
            Grid.SetRow(label, randRow);
            TableGrid.Children.Add(label);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //MyWindow (saját ablak) példányosítása
            MyWindow tempWindow = new MyWindow
            {
                //Mindig az eredeti ablak felett marad és ha bezárjuk az eredetit akkor ez is bezáródik
                Owner = this,
                //pozíció manuális megadása
                WindowStartupLocation = WindowStartupLocation.Manual,
                //A mértékegység DIP (Device Independent Pixel) ami 1/96 inch-nek felel meg
                /*Left = 1000,
                Top = 500*/
                //Képernyő méretének felhasználásával
                Left = 100,
                Top = 100,
                Width = 200,
                Height = 200,
                //Számolás
                count = 1
            };
            //Megjelenítése 
            tempWindow.Show();
        }
    }
}