using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
    /// Interaction logic for RecreateUserControl.xaml
    /// </summary>
    public partial class RecreateUserControl : UserControl
    {
        public RecreateUserControl()
        {
            InitializeComponent();
        }

        private string pathA = null;
        private string pathB = null;

        private Bitmap result = null;


        private void SelectButtonA_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Bitmap files|*.bmp";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                pathA = dlg.FileName;
                SelectButtonA.Background = System.Windows.Media.Brushes.DarkOliveGreen;
            }
            else
            {
                pathA = null;
            }
            
        }

        private void SelectButtonB_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Bitmap files|*.bmp";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                pathB = dlg.FileName;
                SelectButtonB.Background = System.Windows.Media.Brushes.DarkOliveGreen;
            }
            else
            {
                pathB = null;
            }
        }

        private void RaiseError(string message)
        {
            ErrorStackPanel.Visibility = Visibility.Visible;
            ErrorLabel.Content = "ERROR: " + message;
        }

        private void DownError()
        {
            ErrorStackPanel.Visibility = Visibility.Hidden;
        }

        private async void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            SaveStockPanel.Visibility = Visibility.Hidden;
            if (pathA == null)
            {
                RaiseError("Select A image, please!");
                return;
            }else if (pathB == null)
            {
                RaiseError("Select B image, please!");
                return;
            }
            DownError();
            VCAEngine engine = new VCAEngine();

            Tuple<string, Bitmap> tuple = null;
            LoadingImage.Visibility = Visibility.Visible;
            await Task.Run(() =>
            {
                tuple = engine.Recreate(pathA, pathB);
            });
            LoadingImage.Visibility = Visibility.Hidden;

            if (tuple.Item1 != null)
            {
                RaiseError(tuple.Item1);
                return;
            }

            result = tuple.Item2;

            DownError();
            SaveStockPanel.Visibility = Visibility.Visible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Bitmap files|*.bmp";
            dlg.FileName = "result.bmp";

            var dialog = dlg.ShowDialog();

            if (dialog == true)
            {
                result.Save(dlg.FileName, ImageFormat.Bmp);
            }
        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            Result result_class = new Result();
            result_class.SetImage(result);
            var a = result_class.ShowDialog();
        }
    }
}
