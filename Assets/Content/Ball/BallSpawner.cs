using UnityEngine;
using System.Collections.Generic;
using UniRx;

namespace SpacePortals
{
    public class BallSpawner : ITalkingAboutCollection<Ball>
    {
        private List<Ball> _spawnedBalls;

        private BallFactory _factory;

        public BallSpawner(BallFactory factory)
        {
            _spawnedBalls = new List<Ball>();

            _factory = factory;
        }

        public IEnumerable<Ball> Collection => _spawnedBalls;

        public void SpawnInTheCenter(BallTypes type)
        {
            Ball ball = _factory.Get(type, Vector3.up);

            SubscribeToDestroyBallTracking(ball);
            _spawnedBalls.Add(ball);
        }
        public void SpawnInThePosition(BallTypes type, Vector3 position)
        {
            Ball ball = _factory.Get(type, position);

            SubscribeToDestroyBallTracking(ball);
            _spawnedBalls.Add(ball);
        }

        public void DestroyAllSpawnedBalls()
        {
            while (_spawnedBalls.Count > 0)
                _spawnedBalls[0].Destroy();
        }

        private void SubscribeToDestroyBallTracking(Ball ball)
            => ball.OnDestroy.Subscribe(_ => _spawnedBalls.Remove(ball)).AddTo(ball);
    }
}