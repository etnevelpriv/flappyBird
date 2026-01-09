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
        double canvasMagassag = 0;
        double canvasSzelesseg = 0;

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

        private async void palyaButtonNapos_Click(object sender, RoutedEventArgs e)
        {
            await renderGame("napos", "pack://application:,,,/Images/napos.png");
            gameCanvasSizeModifier();
        }

        private async void palyaButtonEsos_Click(object sender, RoutedEventArgs e)
        {
            await renderGame("esos", "pack://application:,,,/Images/esos.png");
            gameCanvasSizeModifier();
        }

        private async void palyaButtonKodos_Click(object sender, RoutedEventArgs e)
        {
            kod.Visibility = Visibility.Visible;
            await renderGame("kodos", "pack://application:,,,/Images/kodos.png");
            gameCanvasSizeModifier();
        }

        private async Task renderGame(string nehezseg, string imageSource)
        {
            backgroundImage.ImageSource = new BitmapImage(new Uri(imageSource));
            aktivNehezseg = nehezseg;

            palyaValasztoGrid.Visibility = Visibility.Collapsed;
            gameCanvas.Visibility = Visibility.Visible;
        }

        private void gameCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gameCanvasSizeModifier();
        }

        private void gameCanvasSizeModifier()
        {
            canvasMagassag = gameCanvas.ActualHeight;
            canvasSzelesseg = gameCanvas.ActualWidth;
            egerText.Text = canvasMagassag.ToString();
            double egerTop = canvasMagassag / 2 - 75;
            Canvas.SetTop(eger, egerTop);

            if (kod.Visibility == Visibility.Visible)
            {
                kod.Width = canvasSzelesseg * 1.5;
                kod.Height = canvasMagassag;
            }
        }
    }
}