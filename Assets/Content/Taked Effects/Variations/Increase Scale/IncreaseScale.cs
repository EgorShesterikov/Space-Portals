using UnityEngine;

namespace SpacePortals
{
    public class IncreaseScale : BuffEffect
    {
        [SerializeField] private float _increaseScaleValue = 0.5f;

        protected override void ApplyEffectToBall(Ball ball)
            => ball.Scale = ball.Scale + _increaseScaleValue;
    }
}