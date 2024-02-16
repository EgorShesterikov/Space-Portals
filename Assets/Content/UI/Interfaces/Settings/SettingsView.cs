using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SpacePortals
{
    public class SettingsView : WindowsBase, IDisposable
    {
        [SerializeField] private SliderSelectable _musicSlider;
        [SerializeField] private SliderSelectable _sfxSlider;
        [SerializeField] private Button _backButton;

        private CompositeDisposable _disposables = new CompositeDisposable();

        public ReactiveCommand<float> OnChangedMusicSlider = new();
        public ReactiveCommand<float> OnChangedSFXSlider = new();
        public ReactiveCommand OnClickedBackButton = new();

        public SliderSelectable MusicSlider => _musicSlider;
        public SliderSelectable SfxSlider => _sfxSlider;

        public void Awake()
        {
            _musicSlider.OnValueChangedAsObservable()
                .Where(_ => _musicSlider.IsTouching == true)
                .Subscribe(value => 
                {
                    OnChangedMusicSlider.Execute(value);
                }).AddTo(_disposables);

            _sfxSlider.OnValueChangedAsObservable()
                .Where(_ => _sfxSlider.IsTouching == true)
                .Subscribe(value =>
                {
                    OnChangedSFXSlider.Execute(value);
                }).AddTo(_disposables);

            _backButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    ShakeAnimButton(_backButton);
                    OnClickedBackButton.Execute();
                }).AddTo(_disposables);
        }

        public void Dispose()
           => _disposables?.Dispose();
    }
}
