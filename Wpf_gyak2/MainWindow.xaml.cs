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

namespace Wpf_gyak2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var szamok = new int[3] { int.Parse(Szam1.Text), int.Parse(Szam2.Text), int.Parse(Szam3.Text) };

            Eredmeny.Text = szamok.OrderDescending().ToArray()[1] * szamok.OrderDescending().ToArray()[2] + ""; 
        }

        private void Valtozas(object sender, TextChangedEventArgs e)
        {
            int hossz = Szoveg2.Text.Length;
            Honnan.Maximum = hossz-1;
            Meddig.Maximum = hossz-1;
        }

        private void Honnan_TouchMove(object sender, TouchEventArgs e)
        {

        }
    }
}