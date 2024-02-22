using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace SpacePortals
{
    public class PlayController : IDisposable
    {
        private float _timeSwapPortal;
        private float _timeSpawnEffect;

        private float _currentTimeSwapPortal;
        private float _currentTimeSpawnEffect;

        private PlayControllerConfig _config;
        private IEnumerable<Ball> _ballCollection;

        private IDisposable _checkedEndGame;
        private IDisposable _gameProcess;

        public PlayController(PlayControllerConfig cofig, ITalkingAboutCollection<Ball> ballCollection)
        {
            _config = cofig;
            _ballCollection = ballCollection.Collection;

            _timeSwapPortal = _config.StartTimeSwapPortal;
            _timeSpawnEffect = _config.StartTimeSpawnTakedEffect;
        }

        public ReactiveCommand AllBallsDestroyed = new();

        public ReactiveCommand SwapPortals = new();
        public ReactiveCommand SpawnTakedEffect = new();

        public void Dispose()
        {
            _checkedEndGame?.Dispose();
            _gameProcess?.Dispose();
        }

        public void StartGame()
        {
            _currentTimeSwapPortal = _timeSwapPortal;
            _currentTimeSpawnEffect = _timeSpawnEffect;

            _checkedEndGame = Observable.EveryUpdate().Where(_ => _ballCollection.Count() == 0).First()
                .Subscribe(_ => AllBallsDestroyed.Execute());

            _gameProcess = Observable.EveryUpdate().Where(_ => _ballCollection.Count() > 0)
                .Subscribe(_ => GameProcess());
        }

        private void GameProcess()
        {
            _currentTimeSwapPortal -= Time.deltaTime;
            if(_currentTimeSwapPortal < 0)
            {
                SwapPortals.Execute();

                float changeTimeSwapPortal = _timeSwapPortal * _config.AccelerationCoefficient;

                if (changeTimeSwapPortal >= _config.MinTimeSwapPortal)
                    _timeSwapPortal = changeTimeSwapPortal;

                _currentTimeSwapPortal = _timeSwapPortal;
            }

            _currentTimeSpawnEffect -= Time.deltaTime;
            if(_currentTimeSpawnEffect < 0)
            {
                SpawnTakedEffect.Execute();

                float changeTimeSpawnEffect = _timeSpawnEffect * _config.AccelerationCoefficient;

                if (changeTimeSpawnEffect >= _config.MinTimeSpawnTakedEffect)
                    _timeSpawnEffect = changeTimeSpawnEffect;

                _currentTimeSpawnEffect = _timeSpawnEffect;
            }
        }
    }
}