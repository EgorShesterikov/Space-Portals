using DG.Tweening;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SpacePortals
{
    public class PlayMenuView : WindowsBase, IDisposable
    {
        private const float OPEN_CLOSE_POSITION_Y = 100f;
        private const float OPEN_CLOSE_DURATION = 0.5f;

        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        private CompositeDisposable _disposable = new CompositeDisposable();

        public ReactiveCommand OnClickedSettingsButton = new();
        public ReactiveCommand OnClickedExitButton = new();

        public void Awake()
        {
            _settingsButton.OnClickAsObservable()
                .Subscribe(_ => {
                    ShakeAnimButton(_settingsButton);
                    OnClickedSettingsButton.Execute();
                }).AddTo(_disposable);

            _exitButton.OnClickAsObservable()
                .Subscribe(_ => {
                    ShakeAnimButton(_exitButton);
                    OnClickedExitButton.Execute();
                }).AddTo(_disposable);
        }

        public void Dispose()
            => _disposable.Dispose();

        public override void Open()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _sequence.SetUpdate(true)
                .PrependCallback(() =>
            {
                _canvasGroup.blocksRaycasts = false;
                _canvasGroup.alpha = 0;

                _rectTransform.anchoredPosition = new Vector3(0, OPEN_CLOSE_POSITION_Y, 0);

                gameObject.SetActive(true);
            })
                .Append(_canvasGroup.DOFade(1, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .Join(transform.DOLocalMoveY(0, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .AppendCallback(() => _canvasGroup.blocksRaycasts = true);
        }
        public override void Close()
        {
            _sequence?.Kill();
            _sequence = DOTween.Sequence();

            _sequence.SetUpdate(true)
                .PrependCallback(() =>
            {
                _canvasGroup.blocksRaycasts = false;
                _canvasGroup.alpha = 1;

                _rectTransform.anchoredPosition = Vector3.zero;

                gameObject.SetActive(true);
            })
                .Append(_canvasGroup.DOFade(0, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .Join(transform.DOLocalMoveY(OPEN_CLOSE_POSITION_Y, OPEN_CLOSE_DURATION).SetEase(Ease.InCirc))
                .AppendCallback(() => gameObject.SetActive(false));
        }
    }
}