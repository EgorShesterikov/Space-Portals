using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SpacePortals
{
    public class PlayerControllerView : WindowsBase, IDisposable
    {
        [SerializeField] private Button _leftArrowButton;
        [SerializeField] private Button _rightArrowButton;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCommand OnClickedLeftArrowButton = new();
        public ReactiveCommand OnClickedRightArrowButton = new();

        public void Awake()
        {
            _leftArrowButton.OnClickAsObservable()
                .Subscribe(_ => OnClickedLeftArrowButton.Execute())
                .AddTo(_disposables);

            _rightArrowButton.OnClickAsObservable()
                .Subscribe(_ => OnClickedRightArrowButton.Execute())
                .AddTo(_disposables);
        }

        public void Dispose()
            => _disposables.Dispose();

        public override void Open()
            => _canvasGroup.interactable = true;
        public override void Close()
            => _canvasGroup.interactable = false;
    }
}
