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
    /// Interaction logic for CreateUserControl.xaml
    /// </summary>
    public partial class CreateUserControl : UserControl
    {
        public CreateUserControl()
        {
            InitializeComponent();
        }

        private string path = null;
        private Bitmap resultA = null;
        private Bitmap resultB = null;

        private void SecretsTogglebutton_Click(object sender, RoutedEventArgs e)
        {
            if (SecretsTogglebutton.IsChecked.Value)
            {
                SecretsLabel.Content = "2 secrets 4 pixels";
            }
            else
            {
                SecretsLabel.Content = "2 secrets 2 pixels";
            }
        }


        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Bitmap files|*.bmp";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                path = dlg.FileName;
                SelectButton.Background = System.Windows.Media.Brushes.DarkOliveGreen;
            }
            else
            {
                path = null;
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
            if (path == null)
            {
                RaiseError("Select image, please!");
                return;
            }

            VCAEngine engine = new VCAEngine();

            Bitmap[] bitmaps = null;
            DownError();
            LoadingImage.Visibility = Visibility.Visible;
            if (SecretsTogglebutton.IsChecked.Value)
            {
                await Task.Run(() =>
                {
                    bitmaps = engine.Create_4(path);
                });
                
            }
            else
            {
                await Task.Run(() =>
                {
                    bitmaps = engine.Create_2(path);
                });
                
            }
            LoadingImage.Visibility = Visibility.Hidden;
            DownError();
            resultA = bitmaps[0];
            resultB = bitmaps[1];

            SaveStockPanel.Visibility = Visibility.Visible;
        }

        private void SaveAButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Bitmap files|*.bmp";
            dlg.FileName = "resultA.bmp";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                resultA.Save(dlg.FileName, ImageFormat.Bmp);
            }
        }

        private void SaveBButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Bitmap files|*.bmp";
            dlg.FileName = "resultB.bmp";

            var result = dlg.ShowDialog();

            if (result == true)
            {
                resultB.Save(dlg.FileName, ImageFormat.Bmp);
            }
        }

        private void PreviewAButton_Click(object sender, RoutedEventArgs e)
        {
            Result result_class = new Result();
            result_class.SetImage(resultA);
            var a = result_class.ShowDialog();
        }

        private void PreviewBButton_Click(object sender, RoutedEventArgs e)
        {
            Result result_class = new Result();
            result_class.SetImage(resultB);
            var a = result_class.ShowDialog();
        }
    }
}
