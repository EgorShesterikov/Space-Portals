using System;
using UniRx;

namespace SpacePortals
{
    public abstract partial class Model
    {
        private const float AUDIO_MIN_VOLUME = 0.0001f;
        private const float AUDIO_MAX_VOLUME = 1f;
        private const float AUDIO_DEFAULT_MUSIC_VOLUME = 0.5f;
        private const float AUDIO_DEFAULT_SFX_VOLUME = 0.25f;

        private BallTypes _ballType;

        public Model() 
        {
            _ballType = BallTypes.Default;

            Stars = new(0);
            CollectedStars = new(0);

            RecordTime = new(0);
            CurrentTime = new(0);

            MusicVolume = new(AUDIO_DEFAULT_MUSIC_VOLUME);
            SfxVolume = new(AUDIO_DEFAULT_SFX_VOLUME);

            CurrentInterface = new(TypesInterface.MainMenu);
            PreviousInterface = CurrentInterface.Value;
        }

        public BallTypes BallType => _ballType;

        public ReactiveProperty<int> Stars { get; private set; }
        public ReactiveProperty<int> CollectedStars { get; private set; }

        public ReactiveProperty<int> CurrentTime { get; private set; }
        public ReactiveProperty<int> RecordTime { get; private set; } 

        public ReactiveProperty<float> MusicVolume { get; private set; }
        public ReactiveProperty<float> SfxVolume { get; private set; }

        public ReactiveProperty<TypesInterface> CurrentInterface { get; private set; }
        public TypesInterface PreviousInterface { get; private set; }

        public void ChangeBallType(BallTypes type)
            => _ballType = type;

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
