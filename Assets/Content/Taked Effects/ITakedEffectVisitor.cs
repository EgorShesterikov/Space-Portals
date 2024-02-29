namespace SpacePortals
{
    public interface ITakedEffectVisitor
    {
        void Visit(Bomb effect);
        void Visit(Star effect);
        void Visit(BuffEffect effect);
    }
}