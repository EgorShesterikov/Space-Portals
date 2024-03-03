using UnityEngine;
using Zenject;

namespace SpacePortals
{
    public class PlayerInput : ITickable
    {
        private float _horizontalAxis;

        public float HorizontalAxis => _horizontalAxis;

        public void Tick()
            => _horizontalAxis = Input.GetAxis("Horizontal");
    }
}