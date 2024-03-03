using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace SpacePortals
{
    public class TakedEffectSpawner : MonoBehaviour
    {
        private const float MAX_X_POSITION = 1.7f;
        private const float MIN_X_POSITION = -1.7f;
        private const float MAX_Y_POSITION = 3;
        private const float MIN_Y_POSITION = -1.5f;

        private AudioComponent _audio;

        private TakedEffectSoundVisitor _soundVisitor;

        private List<TakedEffect> _takedEffectCollection;

        private TakedEffectFactory _factory;

        [Inject]
        public void Constructor(TakedEffectFactory factory)
        {   
            _takedEffectCollection = new List<TakedEffect>();

            _factory = factory;

            _audio = GetComponent<AudioComponent>();

            _soundVisitor = new TakedEffectSoundVisitor(_audio);
        }

        public TakedEffect SpawnInTheRandomPosition(TakedEffectTypes type)
        {
            TakedEffect takedEffect = _factory.Get(type, GetRandomPositionInPlayZone());

            SubscribeToTriggerEnterTakedEffectTracking(takedEffect);
            SubscribeToDestroyTakedEffectTracking(takedEffect);

            _takedEffectCollection.Add(takedEffect);

            return takedEffect;
        }

        public void DestroyAllSpawnedTakedEffect()
        {
            while (_takedEffectCollection.Count > 0)
                _takedEffectCollection[0].BallDestroy();
        }

        private Vector3 GetRandomPositionInPlayZone()
            => new Vector3(Random.Range(MIN_X_POSITION, MAX_X_POSITION),
                Random.Range(MIN_Y_POSITION, MAX_Y_POSITION),
                0);

        private void SubscribeToTriggerEnterTakedEffectTracking(TakedEffect takedEffect)
        {
            takedEffect.TriggerEntered.Subscribe(_ => {
                takedEffect.Accept(_soundVisitor);
                }).AddTo(takedEffect);
        }
        private void SubscribeToDestroyTakedEffectTracking(TakedEffect takedEffect)
        {
            takedEffect.Destroyed.Subscribe(_ => {
                _takedEffectCollection.Remove(takedEffect);
            }).AddTo(takedEffect);
        }

        private class TakedEffectSoundVisitor : ITakedEffectVisitor
        {
            private AudioComponent _audio;

            public TakedEffectSoundVisitor(AudioComponent audio)
                => _audio = audio;

            public void Visit(Bomb effect)
                => _audio.PlaySound("TakeBomb");
            public void Visit(Star effect)
                => _audio.PlaySound("TakeStar");
            public void Visit(BuffEffect effect)
                => _audio.PlaySound("TakeBuff");
        }
    }
}