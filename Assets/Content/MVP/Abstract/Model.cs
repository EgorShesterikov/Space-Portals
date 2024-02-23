using System;
using System.Collections.Generic;
using UniRx;

namespace SpacePortals
{
    public abstract partial class Model
    {
        private const float AUDIO_MIN_VOLUME = 0.0001f;
        private const float AUDIO_MAX_VOLUME = 1f;

        private const int BALL_COST_MULTIPLICATOR = 10;

        private List<BallSkinInfo> _infoBalls;
        private BallTypes _ballType;

        public Model() 
        {
            StoreBallType = new(_ballType);

            CollectedStars = new(0);

            CurrentTime = new(0);

            CurrentInterface = new(TypesInterface.MainMenu);
            PreviousInterface = CurrentInterface.Value;
        }

        public BallTypes BallType => _ballType;
        public ReactiveProperty<BallTypes> StoreBallType { get; private set; }

        public ReactiveProperty<int> Stars { get; private set; }
        public ReactiveProperty<int> CollectedStars { get; private set; }

        public ReactiveProperty<int> CurrentTime { get; private set; }
        public ReactiveProperty<int> RecordTime { get; private set; } 

        public ReactiveProperty<float> MusicVolume { get; private set; }
        public ReactiveProperty<float> SfxVolume { get; private set; }

        public ReactiveProperty<TypesInterface> CurrentInterface { get; private set; }
        public TypesInterface PreviousInterface { get; private set; }

        public void LoadModel(ProgressJSON progress)
        {
            _infoBalls = new List<BallSkinInfo>(progress.InfoBalls);

            _ballType = progress.BallType;

            Stars = new(progress.Stars);

            RecordTime = new(progress.RecordTime);

            MusicVolume = new(progress.MusicValue);
            SfxVolume = new(progress.SFXValue);
        }
        public ProgressJSON SaveModel()
            => new ProgressJSON(_infoBalls, BallType, Stars.Value, RecordTime.Value, MusicVolume.Value, SfxVolume.Value);

        public bool CheckOpenedBallInCollection()
            => _infoBalls.Find(ball => ball.Type == StoreBallType.Value).IsOpen;
        public void OpenBallInCollection()
            => _infoBalls.Find(ball => ball.Type == StoreBallType.Value).IsOpen = true;

        public void GoNextStoreBallType()
        {
            if ((int)StoreBallType.Value < Enum.GetNames(typeof(BallTypes)).Length - 1)
                StoreBallType.Value++;
            else
                StoreBallType.Value = 0;
        }
        public void GoPreviousStoreBallType()
        {
            if ((int)StoreBallType.Value > 0)
                StoreBallType.Value--;
            else
                StoreBallType.Value = (BallTypes)(Enum.GetNames(typeof(BallTypes)).Length - 1);
        }

        public int GetCostStoreBallType()
            => (int)StoreBallType.Value * BALL_COST_MULTIPLICATOR;

        public void ChangeStoreBallTypeToPlayerBallType()
            => StoreBallType.Value = _ballType;
        public void ChangePlayerBallTypeToStoreBallType()
        {
            if(CheckOpenedBallInCollection())
                _ballType = StoreBallType.Value;
        }


        public void AddStar()
        {
            Stars.Value++;
            CollectedStars.Value++;
        }
        public void RemoveStars(int value)
        {
            if (Stars.Value - value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            Stars.Value -= value;
        }
        public void ResetCollectedStars()
            => CollectedStars.Value = 0;

        public void AddSecondCurrentTime()
            => CurrentTime.Value++;
        public void CheckUpdateRecord()
        {
            if (CurrentTime.Value > RecordTime.Value)
                RecordTime.Value = CurrentTime.Value;
        }
        public void ResetCurrentTime()
            => CurrentTime.Value = 0;

        public void ChangeMusic(float volume)
        {
            if (volume < AUDIO_MIN_VOLUME || volume > AUDIO_MAX_VOLUME)
                throw new ArgumentOutOfRangeException(nameof(volume));

            MusicVolume.Value = volume;
        }
        public void ChangeSFX(float volume)
        {
            if (volume < AUDIO_MIN_VOLUME || volume > AUDIO_MAX_VOLUME)
                throw new ArgumentOutOfRangeException(nameof(volume));

            SfxVolume.Value = volume;
        }

        public void ChangeTargetInterface(TypesInterface targetInterface)
        {
            PreviousInterface = CurrentInterface.Value;
            CurrentInterface.Value = targetInterface;
        }
    }
}
