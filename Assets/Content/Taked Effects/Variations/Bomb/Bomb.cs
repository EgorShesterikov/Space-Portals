namespace SpacePortals
{
    public class Bomb : TakedEffect
    {
        protected override void ApplyEffectToBall(Ball ball)
            => ball.Destroy();
    }
}