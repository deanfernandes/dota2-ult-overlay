using Emgu.CV.Features2D;
using System.Diagnostics;
using System.IO;
using System.Windows;
using static Emgu.CV.OCR.Tesseract;

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
        }
    }
}