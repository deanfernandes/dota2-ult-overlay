using NLog;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace DeanFernandes.Dota2UltOverlay.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<HeroUltViewModel> _heroUltViewModels;
        public ObservableCollection<HeroUltViewModel> HeroUltViewModels
        {
            get
            {
                return _heroUltViewModels;
            }
            set
            {
                if (_heroUltViewModels != value)
                {
                    _heroUltViewModels = value;
                    NotifyPropertyChanged(nameof(HeroUltViewModels));
                }
            }
        }

        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public MainWindowViewModel()
        {
            HeroUltViewModels = new ObservableCollection<HeroUltViewModel>();

            PopulateHeroes();
        }

        private void PopulateHeroes()
        {
#if DEBUG
            logger.Debug("function PopulateHeroes started");
            var stopwatch = Stopwatch.StartNew();
#endif

            ScreenCapture.SaveBitmapToFilePng(ScreenCapture.CaptureScreenBitmap(), "screenshot");

            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images\Heroes\");
            try
            {
                foreach (string file in Directory.EnumerateFiles(directoryPath))
                {
                    //TODO: rm test code
                    //bool match = ImageProcessor.PerformTemplateMatch(Path.Combine(Directory.GetCurrentDirectory(), "screenshot.png"), file);
                    bool match = ImageProcessor.PerformTemplateMatch(@"C:\Users\work\Desktop\repos\dota2-ult-overlay\DeanFernandes.Dota2UltOverlay\DeanFernandes.Dota2UltOverlay\screenshot_eg.png", file);

                    if (match)
                    {
                        HeroUltViewModels.Add(new HeroUltViewModel(new Models.Hero(Path.GetFileNameWithoutExtension(file), new Models.Ultimate("freezing_field", 90))));
                    }
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                logger.Error($"Directory not found: {ex.Message}");

                Debug.WriteLine($"Directory not found: {ex.Message}");
            }

#if DEBUG
            stopwatch.Stop();
            logger.Debug($"function PopulateHeroes finished: {stopwatch.ElapsedMilliseconds}ms");
#endif
        }
    }
}
