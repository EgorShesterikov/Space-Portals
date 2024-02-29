namespace SpacePortals
{
    public abstract class BuffEffect : TakedEffect 
    {
        public override void Accept(ITakedEffectVisitor visitor)
            => visitor.Visit(this);
    }
}