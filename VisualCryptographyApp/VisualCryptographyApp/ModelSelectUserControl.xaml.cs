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
   
    public partial class ModelSelectUserControl : UserControl
    {

        private StartUserControl.ModeEnum mode;


        public ModelSelectUserControl(StartUserControl.ModeEnum mode)
        {
            InitializeComponent();
            this.mode = mode;
        }

        private void TwoModeButton_Click(object sender, RoutedEventArgs e)
        {
            if(mode == StartUserControl.ModeEnum.Create)
            {
                MainGrid.Children.Add(new Create2UserControl());
            }
            else
            {
                MainGrid.Children.Add(new Recreate2UserControl());
            }
        }

        private void FourModeButton_Click(object sender, RoutedEventArgs e)
        {
            if (mode == StartUserControl.ModeEnum.Create)
            {
                MainGrid.Children.Add(new Create4UserControl());
            }
            else
            {
                MainGrid.Children.Add(new Recreate4UserControl());
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Panel).Children.Remove(this);
        }
    }
}
