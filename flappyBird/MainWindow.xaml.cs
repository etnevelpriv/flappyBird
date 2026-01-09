using System.Numerics;
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
        string aktivNehezseg = "";

        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            menuGrid.Visibility = Visibility.Collapsed;
            palyaValasztoGrid.Visibility = Visibility.Visible;
        }
        private void achievementShowButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void palyaButtonNapos_Click(object sender, RoutedEventArgs e)
        {
            aktivNehezseg = "napos";
            backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/napos.png"));
            palyaValasztoGrid.Visibility = Visibility.Collapsed;
            gameCanvas.Visibility = Visibility.Visible;
            renderGameCanvas();
        }

        private void palyaButtonEsos_Click(object sender, RoutedEventArgs e)
        {
            aktivNehezseg = "esos";
            backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/esos.png"));
            palyaValasztoGrid.Visibility = Visibility.Collapsed;
            gameCanvas.Visibility = Visibility.Visible;
            renderGameCanvas();
        }

        private void palyaButtonKodos_Click(object sender, RoutedEventArgs e)
        {
            aktivNehezseg = "kodos";
            backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/kodos.png"));
            palyaValasztoGrid.Visibility = Visibility.Collapsed;
            gameCanvas.Visibility = Visibility.Visible;
            renderGameCanvas();
        }

        private async void renderGameCanvas()
        {
            await Task.Delay(10);
            double canvasMagassag = gameCanvas.ActualHeight;
            double canvasSzelesseg = gameCanvas.ActualWidth;
            egerText.Text = canvasMagassag.ToString();
            double egerTop = canvasMagassag / 2;
            Canvas.SetTop(eger, egerTop);
        }
    }
}