using System.Collections.Generic;
using UnityEngine;

namespace SpacePortals
{
    [CreateAssetMenu(fileName = "BallFactoryConfig", menuName = "Factory/BallFactoryConfig")]
    public class BallFactoryConfig : ScriptableObject
    {
        [SerializeField] private List<BallConfig> _ballsCollection;

        public Ball FindTypeBall(BallTypes type)
        {
            Ball ball = _ballsCollection.Find(ball => ball.Type == type).Ball;

            if(ball == null)
                throw new System.ArgumentNullException(nameof(ball));

            return ball;
        }

        [System.Serializable]
        private struct BallConfig
        {
            public BallTypes Type;
            public Ball Ball;
        }
    }
}