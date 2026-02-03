using System.IO;
using System.Linq;
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

namespace wpf_gyak1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter write = new StreamWriter("nevek.txt", true, Encoding.UTF8);

            write.WriteLine(input.Text);
            input.Clear();
            write.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var nevek = File.ReadAllLines("nevek.txt", Encoding.UTF8);
            
            Lista.ItemsSource = nevek.Order();
        }
    }
}