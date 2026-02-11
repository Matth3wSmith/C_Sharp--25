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

            //Grid táblázat létrehozása
            for (int i = 0; i < row; i++)
            {
                RowDefinition ujSor = new RowDefinition
                {
                    Height = GridLength.Auto
                };
                MainGrid.RowDefinitions.Add(ujSor);

            }
            for (int i = 0; i < row; i++)
            {
                ColumnDefinition ujOszlop = new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                };

                MainGrid.ColumnDefinitions.Add(ujOszlop);
            }
            Grid.SetRow(Szoveg, 0);
            Grid.SetColumn(Szoveg, 0);
            Grid.SetRow(Gomb, 0);
            Grid.SetColumn(Gomb, 0);

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
            MainGrid.Children.Add(label);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}