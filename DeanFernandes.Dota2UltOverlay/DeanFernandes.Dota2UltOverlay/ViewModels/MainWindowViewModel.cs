using DeanFernandes.Dota2UltOverlay.Models;
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

            string filePath = "screenshot";
            ScreenCapturer.SaveBitmapToFilePng(ScreenCapturer.CaptureScreenBitmap(330, 150, 1050), filePath);

            var heroes = HeroProcessor.ProcessHeroes(filePath + ".png");

            foreach (var hero in heroes)
            {
                HeroUltViewModels.Add(new HeroUltViewModel(new Models.Hero(hero)));
            }
        }
    }
}