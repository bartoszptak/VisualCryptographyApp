using Microsoft.Win32;
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
    /// Interaction logic for Create2UserControl.xaml
    /// </summary>
    public partial class Create2UserControl : UserControl
    {
        public Create2UserControl()
        {
            InitializeComponent();
        }

        private string[] fileNames = new string[1];

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog res = new OpenFileDialog();

            res.Filter = "BitMap Files|*.bmp";

            if (res.ShowDialog() == true)
            {
                fileNames[0] = res.FileName;
                SelectImageButton.Background = Brushes.DarkSlateGray;
            }
    
        }
    }
}
