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

        private ObservableCollection<HeroViewModel> _heroViewModels;
        public ObservableCollection<HeroViewModel> HeroViewModels
        {
            get
            {
                return _heroViewModels;
            }
            set
            {
                if (_heroViewModels != value)
                {
                    _heroViewModels = value;
                    NotifyPropertyChanged(nameof(HeroViewModels));
                }
            }
        }

        public MainWindowViewModel()
        {
            _heroViewModels = new ObservableCollection<HeroViewModel>();

            string filePath = "screenshot";
            ScreenCapturer.SaveBitmapToFilePng(ScreenCapturer.CaptureScreenBitmap(330, 150, 1050), filePath);

            var heroes = HeroProcessor.ProcessHeroes(filePath + ".png");
            foreach (var hero in heroes)
            {
                var h = new Models.Hero(hero);
                if (h.Ultimate.CooldownDurationSeconds > 0)
                {
                    HeroViewModels.Add(new HeroViewModel(h));
                }
            }
        }
    }
}