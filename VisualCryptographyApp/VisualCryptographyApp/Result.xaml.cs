using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Shapes;

namespace VisualCryptographyApp
{
    public partial class Result : Window
    {

        public Result()
        {
            InitializeComponent();
        }

        public void SetImage(Bitmap  bitmapOld)
        {
            Bitmap bitmap;
            if (bitmapOld.Width > 800)
            {
                bitmap = new Bitmap(bitmapOld, new System.Drawing.Size(800, bitmapOld.Height * 800 / bitmapOld.Width));
            }
            else if (bitmapOld.Height > 600)
            {
                bitmap = new Bitmap(bitmapOld, new System.Drawing.Size(600 * bitmapOld.Width / bitmapOld.Height, 600));
            }
            else
            {
                bitmap = bitmapOld;
            }

            if (ShowImage != null)
            {
                

                ShowImage.Height = bitmap.Height;
                ShowImage.Width = bitmap.Width;

                using (MemoryStream memory = new MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();

                    ShowImage.Source = bitmapimage;
                }
                 
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
