using UnityEngine;

namespace SpacePortals
{
    [CreateAssetMenu(fileName = "ProgressManagerConfig", menuName = "Save/ProgressManagerConfig")]
    public class ProgressManagerConfig : BaseSaveConfig
    {
        [Range(0, 1), SerializeField] private float _defaultMusicValue;
        [Range(0, 1), SerializeField] private float _defaultSfxValue;

        public float DefaultMusicValue => _defaultMusicValue;
        public float DefaultSfxValue => _defaultSfxValue;
    }
}
