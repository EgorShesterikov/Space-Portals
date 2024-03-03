namespace SpacePortals
{
    public class Bomb : TakedEffect
    {
        public override void Accept(ITakedEffectVisitor visitor)
            => visitor.Visit(this);

        protected override void ApplyEffectToBall(Ball ball)
            => ball.Destroy();
    }
}