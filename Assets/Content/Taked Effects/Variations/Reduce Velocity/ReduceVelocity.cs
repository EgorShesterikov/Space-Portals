using UnityEngine;

namespace SpacePortals
{
    public class ReduceVelocity : BuffEffect
    {
        [SerializeField] private float _reduceVelocityValue = 2f;

        protected override void ApplyEffectToBall(Ball ball)
            => ball.Velocity = ball.Velocity - _reduceVelocityValue;
    }
}