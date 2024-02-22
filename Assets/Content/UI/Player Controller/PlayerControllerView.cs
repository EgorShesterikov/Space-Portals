using System;
using UniRx;
using UnityEngine;

namespace SpacePortals
{
    public class PlayerControllerView : WindowsBase, IDisposable
    {
        [SerializeField] private ButtonSelectable _leftArrowButton;
        [SerializeField] private ButtonSelectable _rightArrowButton;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCommand OnClickedLeftArrowButton = new();
        public ReactiveCommand OnClickedRightArrowButton = new();

        public ButtonSelectable LeftArrowButton => _leftArrowButton;
        public ButtonSelectable RightArrowButton => _rightArrowButton;

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
