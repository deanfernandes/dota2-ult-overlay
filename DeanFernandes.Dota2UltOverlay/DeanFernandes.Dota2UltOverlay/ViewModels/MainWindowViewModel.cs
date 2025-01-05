using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public MainWindowViewModel()
        {
            _heroUltViewModels = new ObservableCollection<HeroUltViewModel>();

            PopulateHeroes();
        }

        private void PopulateHeroes()
        {
            ScreenCapture.SaveBitmapToFilePng(ScreenCapture.CaptureScreenBitmap(), "screenshot");

            var heroes = HeroProcessor.ProcessHeroes("screenshot.png");

            foreach (var hero in heroes)
            {
                HeroUltViewModels.Add(new HeroUltViewModel(new Models.Hero(hero, new Models.Ultimate("death_ward", 100))));
            }
        }
    }
}
