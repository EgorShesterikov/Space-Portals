using System;
using System.Collections.Generic;

namespace SpacePortals
{
    [Serializable]
    public struct ProgressJSON
    {
        public List<BallSkinInfo> InfoBalls;
        public BallTypes BallType;

        public int Stars;
        public int RecordTime;

        public float MusicValue;
        public float SFXValue;

        public bool IsTutorial;

        public ProgressJSON(List<BallSkinInfo> infoBalls, BallTypes ballTypes, 
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
