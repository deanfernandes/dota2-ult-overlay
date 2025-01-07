using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace DeanFernandes.Dota2UltOverlay.Models
{
    class UltimateTimer : INotifyPropertyChanged
    {
        private int _cooldownDuration;
        private System.Timers.Timer _timer;
        private int _timeRemaining;

        public delegate void TimerStoppedEventHandler(object? sender, EventArgs e);
        public event TimerStoppedEventHandler? TimerStopped;

        public int TimeRemaining
        {
            get { return _timeRemaining; }
            set { _timeRemaining = value; NotifyPropertyChanged(nameof(TimeRemaining)); }
        }

        public UltimateTimer(int cooldownDuration)
        {
            _cooldownDuration = cooldownDuration;

            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;
        }
        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            TimeRemaining--;

            if (TimeRemaining <= 0)
            {
                _timer.Stop();

                TimerStopped?.Invoke(this, new EventArgs());
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Start()
        {
            TimeRemaining = _cooldownDuration;

            _timer.Start();
        }
    }
}
