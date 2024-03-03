namespace SpacePortals
{
    public class Star : TakedEffect
    {
        public override void Accept(ITakedEffectVisitor visitor)
            => visitor.Visit(this);

        protected override void ApplyEffectToBall(Ball ball) { }
    }
}