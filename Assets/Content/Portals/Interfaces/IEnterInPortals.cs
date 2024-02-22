using UnityEngine;

namespace SpacePortals
{
    public interface IEnterInPortals
    { 
        bool IsTransformInPortal { get; }
        Rigidbody2D Rigidbody2D { get; }

        float XVelocity => Rigidbody2D.velocity.x;
        float YVelocity => Rigidbody2D.velocity.y;

        void ActionInEnter();
        void ActionInExit();
    }
}
