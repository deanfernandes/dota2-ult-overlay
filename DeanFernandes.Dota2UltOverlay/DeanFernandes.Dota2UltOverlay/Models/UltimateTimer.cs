using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Input;

namespace DeanFernandes.Dota2UltOverlay.Models
{
    class UltimateTimer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private System.Timers.Timer _timer;
        private int _cooldownDuration;
        private int _timeRemaining;
        public int TimeRemaining
        {
            get { return _timeRemaining; }
            set { _timeRemaining = value; NotifyPropertyChanged(nameof(TimeRemaining)); }
        }
        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; NotifyPropertyChanged(nameof(IsEnabled)); }
        }

        public ICommand StartTimerCommand { get; }

        public UltimateTimer(int cooldownDuration)
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;

            _cooldownDuration = cooldownDuration;

            StartTimerCommand = new RelayCommand(StartTimer, CanStartTimer);
        }
        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            TimeRemaining--;

            if (TimeRemaining <= 0)
            {
                _timer.Stop();

                IsEnabled = false;
            }
        }

        private void StartTimer()
        {
            TimeRemaining = _cooldownDuration;

            _timer.Start();

            IsEnabled = true;
        }

        private bool CanStartTimer()
        {
            return !IsEnabled;
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
