using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace SpacePortals
{
    public class TakedEffectSpawner
    {
        private const float MAX_X_POSITION = 1.7f;
        private const float MIN_X_POSITION = -1.7f;
        private const float MAX_Y_POSITION = 3;
        private const float MIN_Y_POSITION = -1.5f;

        private List<TakedEffect> _takedEffectCollection;

        private TakedEffectFactory _factory;

        public TakedEffectSpawner(TakedEffectFactory factory)
        {   
            _takedEffectCollection = new List<TakedEffect>();

            _factory = factory;
        }

        public TakedEffect SpawnInTheRandomPosition(TakedEffectTypes type)
        {
            TakedEffect takedEffect = _factory.Get(type, GetRandomPositionInPlayZone());

            SubscribeToDestroyTakedEffectTracking(takedEffect);
            _takedEffectCollection.Add(takedEffect);

            return takedEffect;
        }

        public void DestroyAllSpawnedTakedEffect()
        {
            while (_takedEffectCollection.Count > 0)
                _takedEffectCollection[0].Destroy();
        }

        private Vector3 GetRandomPositionInPlayZone()
            => new Vector3(Random.Range(MIN_X_POSITION, MAX_X_POSITION),
                Random.Range(MIN_Y_POSITION, MAX_Y_POSITION),
                0);

        private void SubscribeToDestroyTakedEffectTracking(TakedEffect takedEffect)
            => takedEffect.OnDestroy.Subscribe(_ => _takedEffectCollection.Remove(takedEffect)).AddTo(takedEffect);
    }
}