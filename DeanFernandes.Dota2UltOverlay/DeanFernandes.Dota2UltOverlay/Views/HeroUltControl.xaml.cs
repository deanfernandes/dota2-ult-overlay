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
using DeanFernandes.Dota2UltOverlay.Models;
using DeanFernandes.Dota2UltOverlay.ViewModels;

namespace DeanFernandes.Dota2UltOverlay.Views
{
    /// <summary>
    /// Interaction logic for HeroUltControl.xaml
    /// </summary>
    public partial class HeroUltControl : UserControl
    {
        public HeroUltControl()
        {
            InitializeComponent();
        }

        private void UltImage_MouseEnter(object sender, MouseEventArgs e)
        {
            UltRectangle.Visibility = Visibility.Visible;
        }

        private void UltImage_MouseLeave(object sender, MouseEventArgs e)
        {
            UltRectangle.Visibility = Visibility.Collapsed;
        }
    }
}
