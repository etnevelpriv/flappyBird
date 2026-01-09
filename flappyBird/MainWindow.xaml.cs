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

namespace flappyBird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int gravitacio = 1;

        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            double canvasMagassag = gameCanvas.ActualHeight;
            double canvasSzelesseg = gameCanvas.ActualWidth;

        }
        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            menuGrid.Visibility = Visibility.Collapsed;
            gameCanvas.Visibility = Visibility.Visible;
        }
        private void achievementShowButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}