using DG.Tweening;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace SpacePortals
{
    public abstract class TakedEffect : MonoBehaviour
    {
        private const float ANIM_START_DURATION = 2.5f;
        private const float ANIM_DEFAULT_DURATION = 1f;
        private const float ANIM_END_DURATION = 1f;
        private const float EFFECT_PUNCH_POWER = 0.025f;

        [SerializeField] private float _lifeTime = 5f;
        [SerializeField] private ParticleSystem _destroyEffect;

        [Space]
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Light2D _light;
        [SerializeField] private ParticleSystem _particle;

        private Sequence _startSequence;
        private Sequence _endSequence;
        private Tween _loopTween;

        private bool _isReady = false;

        private IDisposable _lifeTimer;

        public ReactiveCommand OnDestroy = new();
        public ReactiveCommand OnTriggerEnter = new();

        public void Awake()
        {
            transform.localScale = Vector3.zero;
            _particle.transform.localScale = Vector3.zero;
            _light.volumeIntensity = 0;
            _sprite.color = new Color(1, 1, 1, 0.5f);

            _startSequence = DOTween.Sequence();

            _startSequence.Append(transform.DOScale(1, ANIM_START_DURATION)).SetEase(Ease.InBounce)
                .Join(_particle.transform.DOScale(1, ANIM_START_DURATION)).SetEase(Ease.InBounce)
                .Join(DOTween.To(() => _light.volumeIntensity, value => _light.volumeIntensity = value, 1, ANIM_START_DURATION)).SetEase(Ease.InBounce)
                .Join(_sprite.DOFade(1, ANIM_START_DURATION)).SetEase(Ease.InBounce)
                .SetLink(gameObject)
                .OnComplete(() => StartLifeTime())
                .SetAutoKill();
        }

        public void Destroy()
        {
            OnDestroy.Execute();

            _lifeTimer?.Dispose();

            Instantiate(_destroyEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        protected abstract void ApplyEffectToBall(Ball ball);

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Ball ball) && _isReady == true)
            {
                OnTriggerEnter.Execute();

                ApplyEffectToBall(ball);
                Destroy();
            }
        }

        private void StartLifeTime()
        {
            _isReady = true;

            _loopTween = _sprite.transform.DOPunchScale(Vector3.one * EFFECT_PUNCH_POWER, ANIM_DEFAULT_DURATION, 0, 0)
            .SetEase(Ease.InOutQuart)
            .SetLoops(-1)
            .SetLink(gameObject);

            _lifeTimer = Observable.Timer(TimeSpan.FromSeconds(_lifeTime)).
                Subscribe(_ => EndLifeTime()).AddTo(this);
        }
        private void EndLifeTime()
        {
            _isReady = false;

            _lifeTimer?.Dispose();
            _loopTween?.Kill();

            _endSequence = DOTween.Sequence();

            _endSequence.Append(transform.DOScale(0, ANIM_END_DURATION)).SetEase(Ease.InBounce)
                .Join(_particle.transform.DOScale(0, ANIM_END_DURATION)).SetEase(Ease.InBounce)
                .Join(DOTween.To(() => _light.volumeIntensity, value => _light.volumeIntensity = value, -1, ANIM_END_DURATION)).SetEase(Ease.InBounce)
                .Join(_sprite.DOFade(0.5f, ANIM_END_DURATION)).SetEase(Ease.InBounce)
                .SetLink(gameObject)
                .OnComplete(() => Destroy())
                .SetAutoKill();
        }
    }
}