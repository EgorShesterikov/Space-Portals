using SpacePortals;
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Ваши сохранения

        public List<BallSkinInfo> InfoBalls;
        public BallTypes BallType;

        public int Stars;
        public int RecordTime;

        public float MusicValue;
        public float SFXValue;

        public bool IsTutorial;

        public SavesYG()
        {
            InfoBalls = new List<BallSkinInfo>()
            {
                new BallSkinInfo(BallTypes.Default, true),
                new BallSkinInfo(BallTypes.Magma, false),
                new BallSkinInfo(BallTypes.Rubber, false),
                new BallSkinInfo(BallTypes.Clow, false),
                new BallSkinInfo(BallTypes.Bigger, false),
                new BallSkinInfo(BallTypes.Speedy, false),
            };
            BallType = BallTypes.Default;

            Stars = 0;
            RecordTime = 0;

            MusicValue = -1;
            SFXValue = -1;

            IsTutorial = true;
        }

        public SavesYG(List<BallSkinInfo> infoBalls, BallTypes ballTypes,
            int stars, int recordTime,
            float musicValue, float sfxValue,
            bool isTutorial)
        {
            InfoBalls = infoBalls;

            BallType = ballTypes;

            Stars = stars;
            RecordTime = recordTime;

            MusicValue = musicValue;
            SFXValue = sfxValue;

            IsTutorial = isTutorial;
        }
    }
}
