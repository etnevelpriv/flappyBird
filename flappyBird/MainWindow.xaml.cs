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
using System.Windows.Threading;

namespace flappyBird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double egerYpozicioja;
        string aktivNehezseg;
        double canvasMagassag;
        double canvasSzelesseg;
        double gravitacio;
        double egerHeight;
        double macskaSzelesseg;

        List<Rectangle> macskak = new List<Rectangle>();

        DispatcherTimer jatekTimer;
        DispatcherTimer cicaTimer;
        double sebesseg;

        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            jatekTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16) };
            jatekTimer.Tick += JatekTimer_Tick;

            cicaTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            cicaTimer.Tick += CicaTimer_Tick;
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
            gravitacio = 1.5;
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

            gameCanvas.Focus();
            jatekTimer.Start();
            cicaTimer.Start();

        }

        private void JatekTimer_Tick(object? sender, EventArgs e)
        {
            sebesseg += gravitacio;
            egerYpozicioja += sebesseg;

            double maxTop = (canvasMagassag - eger.Height);
            if (egerYpozicioja < 0)
            {
                egerYpozicioja = 0;
                sebesseg = 0;
            }
            else if (egerYpozicioja > maxTop)
            {
                egerYpozicioja = maxTop;
                sebesseg = 0;
            }

            Canvas.SetTop(eger, egerYpozicioja);
            foreach (Rectangle macska in macskak)
            {
                double macskaPozicio = Canvas.GetRight(macska);
                Canvas.SetRight(macska, (macskaPozicio + 10));
            }
        }

        private void CicaTimer_Tick(object? sender, EventArgs e)
        {
            double lyukMagassag = egerHeight * 3;
            double felsoMacskaMagassag = random.Next((int)(canvasMagassag - lyukMagassag));
            double alsoMacskaMagassag = felsoMacskaMagassag + lyukMagassag;

            Rectangle felsoMacska = new Rectangle();
            felsoMacska.Height = felsoMacskaMagassag;
            felsoMacska.Width = macskaSzelesseg;
            felsoMacska.VerticalAlignment = VerticalAlignment.Center;
            felsoMacska.HorizontalAlignment = HorizontalAlignment.Left;
            Canvas.SetTop(felsoMacska, 0);
            Canvas.SetRight(felsoMacska, 100);
            // Ezt AI-al irattam, nem jottem ra magamtol, dokumentaciot sem talaltam
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("pack://application:,,,/Images/forditottCica.png");
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            felsoMacska.Fill = new ImageBrush
            {
                ImageSource = bitmap
            };

            Rectangle alsoMacska = new Rectangle();
            alsoMacska.Height = alsoMacskaMagassag;
            alsoMacska.Width = macskaSzelesseg;
            alsoMacska.VerticalAlignment = VerticalAlignment.Center;
            alsoMacska.HorizontalAlignment = HorizontalAlignment.Left;
            Canvas.SetTop(alsoMacska, 0);
            Canvas.SetRight(alsoMacska, 100);
            // Ezt AI-al irattam, nem jottem ra magamtol, dokumentaciot sem talaltam
            var bitmapAlso = new BitmapImage();
            bitmapAlso.BeginInit();
            bitmapAlso.UriSource = new Uri("pack://application:,,,/Images/cica.png");
            bitmapAlso.CacheOption = BitmapCacheOption.OnLoad;
            bitmapAlso.EndInit();
            alsoMacska.Fill = new ImageBrush
            {
                ImageSource = bitmapAlso
            };

            gameCanvas.Children.Add(felsoMacska);
            gameCanvas.Children.Add(alsoMacska);
            macskak.Add(alsoMacska);
            macskak.Add(felsoMacska);
        }

        private void gameCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gameCanvasSizeModifier();
        }

        private void gameCanvasSizeModifier()
        {
            canvasMagassag = gameCanvas.ActualHeight;
            canvasSzelesseg = gameCanvas.ActualWidth;

            double egerLeft = canvasSzelesseg /10;
            double egerWidth = canvasSzelesseg / 10;
            egerHeight = egerWidth;
            double egerTop = Canvas.GetTop(eger);
            if (double.IsNaN(egerTop))
            {
                egerTop = (canvasMagassag - egerHeight) / 2;
            }
            eger.Width = egerWidth;
            eger.Height = egerHeight;
            Canvas.SetLeft(eger, egerLeft);
            Canvas.SetTop(eger, egerTop + (egerTop - egerYpozicioja));

            gravitacio = 0.5 * canvasMagassag / 200;

            egerText.Text = ((canvasMagassag - eger.Height) / 2).ToString();

            if (kod.Visibility == Visibility.Visible)
            {
                kod.Width = canvasSzelesseg * 1.5;
                kod.Height = canvasMagassag;
            }

            macskaSzelesseg = canvasSzelesseg / 10;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (gameCanvas.Visibility == Visibility.Visible && e.Key == Key.Space)
            {
                sebesseg = -10;
                e.Handled = true;
            }
        }
    }
}