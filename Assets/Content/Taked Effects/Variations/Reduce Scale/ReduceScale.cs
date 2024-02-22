using UnityEngine;

namespace SpacePortals
{
    public class ReduceScale : TakedEffect
    {
        [SerializeField] private float _reduceScaleValue = 0.5f;

        protected override void ApplyEffectToBall(Ball ball)
            => ball.Scale = ball.Scale - _reduceScaleValue;
    }
}