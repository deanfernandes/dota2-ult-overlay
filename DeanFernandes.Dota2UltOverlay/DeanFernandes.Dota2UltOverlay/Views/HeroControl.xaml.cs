using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeanFernandes.Dota2UltOverlay.Views
{
    /// <summary>
    /// Interaction logic for HeroControl.xaml
    /// </summary>
    public partial class HeroControl : UserControl
    {
        public HeroControl()
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

        private void UltImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //TODO: refactor? (law of demeter)
            if (DataContext is ViewModels.HeroViewModel viewModel && viewModel.Hero.Ultimate.Timer.StartTimerCommand.CanExecute(null))
            {
                viewModel.Hero.Ultimate.Timer.StartTimerCommand.Execute(null);
            }
        }
    }
}
