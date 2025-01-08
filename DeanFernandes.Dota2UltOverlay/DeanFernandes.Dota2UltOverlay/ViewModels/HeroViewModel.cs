namespace DeanFernandes.Dota2UltOverlay.ViewModels
{
    using Models;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    class HeroViewModel : INotifyPropertyChanged
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

        public HeroViewModel(Hero hero)
        {
            Hero = hero;
            //hero.UseUltimate()
            //TODO: refactor (goes against demeter's law)
            Hero.Ult.Timer.TimerStopped += TimerStoppedHandler;

            HeroImagePath = ImageManager.GetHeroImagePath(Hero.Name);
            UltImagePath = ImageManager.GetHeroUltimateImagePath(Hero.Name, Hero.Ult.Name);

            StartCooldownCommand = new RelayCommand(StartCooldown, CanStartCooldown);
        }
        private void StartCooldown()
        {
            Hero.Ult.Timer.Start();

            OnCooldown = true;
        }

        private bool CanStartCooldown()
        {
            //Hero.isultoncooldown()?
            return !OnCooldown;
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

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) => _canExecute();

        public void Execute(object? parameter) => _execute();
    }
}
