using UnityEngine;
using Zenject;

namespace SpacePortals
{
    public class TakedEffectFactory
    {
        private TakedEffectFactoryConfig _config;
        private DiContainer _container;

        public TakedEffectFactory(TakedEffectFactoryConfig config, DiContainer container)
        {
            _config = config;
            _container = container;
        }

        public TakedEffect Get(TakedEffectTypes type, Vector3 position)
            => _container.InstantiatePrefabForComponent<TakedEffect>(_config.FindTypeEffect(type), position, Quaternion.identity, null);
    }
}