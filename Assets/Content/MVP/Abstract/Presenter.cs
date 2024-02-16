using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace SpacePortals
{
    public abstract class Presenter : IInitializable, IDisposable
    {
        protected Model _model;
        protected View _view;

        private AudioSystem _audioSystem;
        private TimeIndication _timeIndication;

        private CompositeDisposable _disposable = new CompositeDisposable();

        public Presenter(Model model, View view, AudioSystem audioSystem, TimeIndication timeIndication)
        {
            _model = model;
            _view = view;
            _audioSystem = audioSystem;
            _timeIndication = timeIndication;
        }

        public void Initialize()
        {
            ViewBinding();
            ModelBinding();
            TimerBinding();
        }

        public void Dispose()
            => _disposable.Dispose();

        private void ViewBinding()
        {
            _view.MainMenuView.OnClickedPlayButton.Subscribe(_ => OnClickPlayButtonInMainMenu()).AddTo(_disposable);
            _view.MainMenuView.OnClickedStoreButton.Subscribe(_ => OnClickStoreButtonInMainMenu()).AddTo(_disposable);
            _view.MainMenuView.OnClickedSettingsButton.Subscribe(_ => OnClickSettingsButtonInMainMenu()).AddTo(_disposable);

            _view.SettingsView.OnChangedMusicSlider.Subscribe(value => OnChangeMusicSliderValueInSettingsMenu(value)).AddTo(_disposable);
            _view.SettingsView.OnChangedSFXSlider.Subscribe(value => OnChangeSFXSliderValueInSettingsMenu(value)).AddTo(_disposable);
            _view.SettingsView.OnClickedBackButton.Subscribe(_ => OnClickBackButtonInSettingMenu()).AddTo(_disposable);

            _view.PlayerControllerView.OnClickedLeftArrowButton.Subscribe(_ => OnClickLeftArrowButtonInPlayerController()).AddTo(_disposable);
            _view.PlayerControllerView.OnClickedRightArrowButton.Subscribe(_ => OnClickRightArrowButtonInPlayerController()).AddTo(_disposable);

            _view.PlayMenuView.OnClickedSettingsButton.Subscribe(_ => OnClickSettingsButtonInPlayMenu()).AddTo(_disposable);
            _view.PlayMenuView.OnClickedExitButton.Subscribe(_ => OnClickExitButtonInPlayMenu()).AddTo(_disposable);

            _view.ResultMenuView.OnClickedBackMainMenuButton.Subscribe(_ => OnClickBackMainMenuInResultMenu()).AddTo(_disposable);

            _view.StoreView.OnClickedSelectButton.Subscribe(_ => OnClickSelectButtonInStoreMenu()).AddTo(_disposable);
        }
        private void ModelBinding()
        {
            _model.Stars.Subscribe(value => {
                _view.DisplayStarsValue(value);
                }).AddTo(_disposable);

            _model.MusicVolume.Subscribe(value => {
                _audioSystem.ChangeAudioMixerVolumeMusic(value);

                if (_view.SettingsView.MusicSlider.IsTouching == false)
                    _view.DisplayOnMusicSliderValue(value);
                }).AddTo(_disposable);

            _model.SfxVolume.Subscribe(value => {
                _audioSystem.ChangeAudioMixerVolumeSFX(value);

                if (_view.SettingsView.SfxSlider.IsTouching == false)
                    _view.DisplayOnSFXSliderValue(value);
                }).AddTo(_disposable);

            _model.CurrentInterface.Subscribe(currentInteface => {
                if (currentInteface == TypesInterface.StoreMenu || currentInteface == TypesInterface.PlayMenu)
                    _view.DisplayOnPlayerController(true);
                else
                    _view.DisplayOnPlayerController(false);
                }).AddTo(_disposable);

            _model.CurrentTime.Where(_ => _model.CurrentInterface.Value == TypesInterface.PlayMenu ||
                    _model.CurrentInterface.Value == TypesInterface.SettingsMenu && _model.PreviousInterface == TypesInterface.PlayMenu)
                .Subscribe(second => _view.DisplayOnCurrentTime(second))
                .AddTo(_disposable);

            _model.RecordTime.First()
                .Subscribe(value => _view.DisplayOnRecordTime(_model.RecordTime.Value))
                .AddTo(_disposable);
        }
        private void TimerBinding()
        {
            _timeIndication.SecondPassed.Subscribe(_ => _model.AddSecondCurrentTime())
                .AddTo(_disposable);
        }

        private void OnClickPlayButtonInMainMenu()
        {
            _view.DisplayOnMainMenu(false);
            _view.DisplayOnPlayMenu(true);

            _model.ResetCurrentTime();

            _view.DisplayOnCurrentTime(0);

            _timeIndication.StartTimer();

            _model.ChangeTargetInterface(TypesInterface.PlayMenu);
        }
        private void OnClickStoreButtonInMainMenu()
        {
            _view.DisplayOnMainMenu(false);
            _view.DisplayOnStoreMenu(true);

            _model.ChangeTargetInterface(TypesInterface.StoreMenu);
        }
        private void OnClickSettingsButtonInMainMenu()
        {
            _view.DisplayOnMainMenu(false);
            _view.DisplayOnSettingsMenu(true);

            _model.ChangeTargetInterface(TypesInterface.SettingsMenu);
        }

        private void OnChangeMusicSliderValueInSettingsMenu(float value)
            => _model.ChangeMusic(value);
        private void OnChangeSFXSliderValueInSettingsMenu(float value)
            => _model.ChangeSFX(value);
        private void OnClickBackButtonInSettingMenu()
        {
            if (_model.PreviousInterface == TypesInterface.MainMenu)
            {
                _view.DisplayOnMainMenu(true);
            }
            else if (_model.PreviousInterface == TypesInterface.PlayMenu)
            {
                _view.DisplayOnPlayMenu(true);
                Time.timeScale = 1;
            }

            _view.DisplayOnSettingsMenu(false);

            _model.ChangeTargetInterface(_model.PreviousInterface);
        }

        private void OnClickLeftArrowButtonInPlayerController()
        {
            if(_model.CurrentInterface.Value == TypesInterface.StoreMenu)
            {
                Debug.Log("Листаем скины влево!");
            }
            else if(_model.CurrentInterface.Value == TypesInterface.PlayMenu)
            {
                Debug.Log("Перемещаем шары влево!");
            }
        }
        private void OnClickRightArrowButtonInPlayerController()
        {
            if (_model.CurrentInterface.Value == TypesInterface.StoreMenu)
            {
                Debug.Log("Листаем скины вправо!");
            }
            else if (_model.CurrentInterface.Value == TypesInterface.PlayMenu)
            {
                Debug.Log("Перемещаем шары вправо!");
            }
        }

        private void OnClickSettingsButtonInPlayMenu()
        {
            _view.DisplayOnPlayMenu(false);
            _view.DisplayOnSettingsMenu(true);

            Time.timeScale = 0;

            _model.ChangeTargetInterface(TypesInterface.SettingsMenu);
        }
        private void OnClickExitButtonInPlayMenu()
            => OnOpenResultGameMenu();

        private void OnOpenResultGameMenu()
        {
            _view.DisplayOnPlayMenu(false);
            _view.DisplayOnResultMenu(true);

            _view.DisplayOnCurrentTimeInResultsMenu(_model.CurrentTime.Value);
            _view.DisplayOnCollectedStarsInResultsMenu(_model.CollectedStars.Value);

            _model.CheckUpdateRecord();
            _model.ResetCurrentTime();

            _view.DisplayOnRecordTime(_model.RecordTime.Value);

            _timeIndication.Dispose();

            _model.ChangeTargetInterface(TypesInterface.ResultsMenu);
        }

        private void OnClickBackMainMenuInResultMenu()
        {
            _view.DisplayOnResultMenu(false);
            _view.DisplayOnMainMenu(true);

            _model.ChangeTargetInterface(TypesInterface.MainMenu);
        }

        private void OnClickSelectButtonInStoreMenu()
        {
            Debug.LogWarning("Если в модели хватает валюты для покупки то выбираем и тратим деньги");

            if (true)
            {
                _view.DisplayOnMainMenu(true);
                _view.DisplayOnStoreMenu(false);
            }

            _model.ChangeTargetInterface(TypesInterface.MainMenu);
        }
    }
}