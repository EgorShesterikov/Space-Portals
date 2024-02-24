using UnityEngine;

namespace SpacePortals
{
    public class IncreaseVelocity : BuffEffect
    {
        [SerializeField] private float _increaseVelocityValue = 2f;

        protected override void ApplyEffectToBall(Ball ball)
            => ball.Velocity = ball.Velocity + _increaseVelocityValue;
    }
}