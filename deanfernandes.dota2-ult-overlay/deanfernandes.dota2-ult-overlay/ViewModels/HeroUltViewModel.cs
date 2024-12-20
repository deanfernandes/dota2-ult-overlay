using System.Timers;

namespace deanfernandes.dota2_ult_overlay.ViewModels
{
    using Models;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    class HeroUltViewModel : INotifyPropertyChanged
    {
        public Hero Hero { get; set; }
        public string HeroImagePath { get; set; }
        public string UltImagePath { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _onCooldown = false;
        public bool OnCooldown
        {
            get
            {
                return _onCooldown;
            }
            set
            {
                if (_onCooldown != value)
                {
                    _onCooldown = value;
                    NotifyPropertyChanged(nameof(OnCooldown));
                }
            }
        }

        public ICommand StartCooldownCommand { get; }

        public HeroUltViewModel(Hero hero)
        {
            Hero = hero;
            //TODO: refactor (goes against demeter's law)
            Hero.Ult.Timer.TimerStopped += TimerStoppedHandler;

            HeroImagePath = ImageManager.GetHeroImagePath(Hero.Name);
            UltImagePath = ImageManager.GetHeroUltimateImagePath(Hero.Name, Hero.Ult.Name);

            StartCooldownCommand = new RelayCommand(StartCooldown);
        }
        private void StartCooldown()
        {
            Hero.Ult.Timer.Start();

            OnCooldown = true;
        }

        private void TimerStoppedHandler (object? sender, EventArgs e)
        {
            OnCooldown = false;
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute ?? (() => true);
        }

        public bool CanExecute(object parameter) => _canExecute();

        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged;
    }
}
