using System.Windows;

namespace DeanFernandes.Dota2UltOverlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModels.MainWindowViewModel();

            SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            PositionWindowRightCenter(e.NewSize.Width, e.NewSize.Height);
        }

        private void PositionWindowRightCenter(double width, double height)
        {
            const double LeftOffset = 75d;

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;

            this.Left = screenWidth - width - LeftOffset;
            this.Top = (screenHeight - height) / 2; // center vertically
        }
    }
}