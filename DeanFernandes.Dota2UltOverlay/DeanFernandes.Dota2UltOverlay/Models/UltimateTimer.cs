using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DeanFernandes.Dota2UltOverlay.Models
{
    class UltimateTimer : INotifyPropertyChanged
    {
        private int _cooldownDuration;
        private DispatcherTimer _timer;
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

            _timer = new DispatcherTimer();// TODO: use diff timer (misuse?)
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object? sender, EventArgs e)
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
