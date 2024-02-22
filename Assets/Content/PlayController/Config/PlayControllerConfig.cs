using System;
using UnityEngine;

namespace SpacePortals
{
    [CreateAssetMenu(fileName = "PlayControllerConfig", menuName = "PlayConfig/PlayControllerConfig")]
    public class PlayControllerConfig : ScriptableObject
    {
        [SerializeField] private float _startTimeSwapPortal = 5f;
        [SerializeField] private float _startTimeSpawnTakedEffect = 5f;

        [Space, Range(0.5f, 1)]
        [SerializeField] private float _accelerationCoefficient = 0.75f;

        [Space]
        [SerializeField, Min(0.1f)] private float _minTimeSwapPortal = 1f;
        [SerializeField, Min(0.1f)] private float _minTimeSpawnTakedEffect = 1f;

        public float StartTimeSwapPortal => _startTimeSwapPortal;
        public float StartTimeSpawnTakedEffect => _startTimeSpawnTakedEffect;
        public float AccelerationCoefficient => _accelerationCoefficient;
        public float MinTimeSwapPortal => _minTimeSwapPortal;
        public float MinTimeSpawnTakedEffect => _minTimeSpawnTakedEffect;
    }
}