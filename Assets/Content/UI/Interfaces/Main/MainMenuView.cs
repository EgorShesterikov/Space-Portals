using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

namespace SpacePortals
{
    public class MainMenuView : WindowsBase, IDisposable
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _storeButton;
        [SerializeField] private Button _settingsButton;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCommand OnClickedPlayButton = new();
        public ReactiveCommand OnClickedStoreButton = new();
        public ReactiveCommand OnClickedSettingsButton = new();

        public void Awake()
        {
            _playButton.OnClickAsObservable().Subscribe(_ =>
            {
                ShakeAnimButton(_playButton);
                OnClickedPlayButton.Execute();
            }).AddTo(_disposables);

            _storeButton.OnClickAsObservable().Subscribe(_ =>
            {
                ShakeAnimButton(_storeButton);
                OnClickedStoreButton.Execute();
            }).AddTo(_disposables);

            _settingsButton.OnClickAsObservable().Subscribe(_ =>
            {
                ShakeAnimButton(_settingsButton);
                OnClickedSettingsButton.Execute();
            }).AddTo(_disposables);
        }

        public void Dispose()
            => _disposables?.Dispose();
    }
}
