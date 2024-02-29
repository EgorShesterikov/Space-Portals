using System;
using UniRx;

namespace SpacePortals
{
    public class TimeIndication : IDisposable
    {
        private IDisposable _timerActiv;

        public ReactiveCommand SecondPassed { get; private set; } = new();

        public void StartTimer()
        {
            Dispose();

            _timerActiv = Observable.Timer(TimeSpan.FromSeconds(1))
            .Repeat()
            .Subscribe(_ => SecondPassed.Execute());
        }

        public void Dispose()
            => _timerActiv?.Dispose();
    }
}
