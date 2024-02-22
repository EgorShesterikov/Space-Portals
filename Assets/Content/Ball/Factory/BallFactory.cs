using Zenject;
using UnityEngine;

namespace SpacePortals
{
    public class BallFactory
    {
        private BallFactoryConfig _config;
        private DiContainer _container;

        public BallFactory(BallFactoryConfig config, DiContainer container)
        {
            _config = config;
            _container = container;
        }

        public Ball Get(BallTypes type, Vector3 position)
            =>  _container.InstantiatePrefabForComponent<Ball>(_config.FindTypeBall(type), position, Quaternion.identity, null);
    }
}