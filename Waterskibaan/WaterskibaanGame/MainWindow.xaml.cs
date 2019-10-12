using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
using Waterskibaan;

namespace WaterskibaanGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Game game = new Game();
        bool aan = false;

        public MainWindow()
        {
            InitializeComponent();
            game.Initialize();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            game.waterskibaan.Start();
            Test.Content = game.waterskibaan.isGestart;

            aan = true;

            while (aan)
            {
                Counter.Content = game.oteCounter;
                Counter.Refresh();
                Thread.Sleep(1000);
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            game.waterskibaan.Stop();
            Test.Content = game.waterskibaan.isGestart;

            aan = false;
        }
    }

    // Hoe het werkt, geen idee, maar het zorgt ervoor dat het UIElement waar het op aangeroepen wordt refreshed.
    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate () { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
