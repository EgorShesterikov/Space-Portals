using YG;

namespace SpacePortals
{
    public class ProgressManager : ISave<SavesYG>, ILoad<SavesYG>
    {
        private ProgressManagerConfig _config;

        public ProgressManager(ProgressManagerConfig config)
            => _config = config;

        public void Save(SavesYG info)
        {
            YandexGame.savesData.InfoBalls = info.InfoBalls;
            YandexGame.savesData.BallType = info.BallType;
            YandexGame.savesData.Stars = info.Stars;
            YandexGame.savesData.RecordTime = info.RecordTime;
            YandexGame.savesData.MusicValue = info.MusicValue;
            YandexGame.savesData.SFXValue = info.SFXValue;
            YandexGame.savesData.IsTutorial = info.IsTutorial;

            YandexGame.SaveProgress();
        }

        public SavesYG Load()
        {
            float MusicValue = YandexGame.savesData.MusicValue == -1 ? _config.DefaultMusicValue : YandexGame.savesData.MusicValue;
            float SFXValue = YandexGame.savesData.SFXValue == -1 ? _config.DefaultSfxValue : YandexGame.savesData.SFXValue;

            SavesYG progress = new SavesYG(
                YandexGame.savesData.InfoBalls,
                YandexGame.savesData.BallType,
                YandexGame.savesData.Stars,
                YandexGame.savesData.RecordTime,
                MusicValue,
                SFXValue,
                YandexGame.savesData.IsTutorial);

            return progress;
        }
    }
}