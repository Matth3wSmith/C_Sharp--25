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

namespace LatinTancok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<List<string>> adatok;
        public MainWindow()
        {
            InitializeComponent();
            adatok = File.ReadAllLines("tancrend.txt").Chunk(3).Select(x=>x.ToList()).ToList();

            feladat2.Content += "\n\tElsőként bemutatott tánc: " + adatok[0][0] + ".\n\tUtolsóként bemutatott tánc: " + adatok[adatok.Count - 1][0];
        }
    }
}