using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SpacePortals
{
    public class ProgressManager : ISave<ProgressJSON>, ILoad<ProgressJSON>
    {
        private ProgressManagerConfig _config;

        public ProgressManager(ProgressManagerConfig config)
            => _config = config;

        public void Save(ProgressJSON info)
        {
            string json = JsonUtility.ToJson(info, true);

            try
            {
                File.WriteAllText(_config.SavePatch, json);
            }
            catch (Exception e)
            {
                Debug.Log($"Warrning: {e}");
            }
        }

        public ProgressJSON Load()
        {
            if (!File.Exists(_config.SavePatch))
            {
                return new ProgressJSON(new List<BallSkinInfo>()
                {
                    new BallSkinInfo(BallTypes.Default, true),
                    new BallSkinInfo(BallTypes.Magma, false),
                    new BallSkinInfo(BallTypes.Rubber, false),
                    new BallSkinInfo(BallTypes.Clow, false),
                    new BallSkinInfo(BallTypes.Bigger, false),
                    new BallSkinInfo(BallTypes.Speedy, false),
                }, BallTypes.Default, 0, 0, _config.DefaultMusicValue, _config.DefaultSfxValue, true);
            }

            try
            {
                string json = File.ReadAllText(_config.SavePatch);

                return JsonUtility.FromJson<ProgressJSON>(json);
            }
            catch (Exception e)
            {
                Debug.Log($"Warrning: {e}");

                return new ProgressJSON();
            }
        }
    }
}