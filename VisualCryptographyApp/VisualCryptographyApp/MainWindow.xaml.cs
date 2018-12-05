using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualCryptographyApp
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

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            //MainGrid.Children.Add(new Main_user_control());
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            //MainGrid.Children.Add(new Main_user_control());
        }

        private void AuthorButton_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            //MainGrid.Children.Add(new Main_user_control());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
