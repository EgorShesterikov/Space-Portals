using System.Collections.Generic;

namespace SpacePortals
{
    public class BallMoveController
    {
        private const float ADD_FORCE_POWER = 10f;

        private IEnumerable<Ball> _activBalls;

        public BallMoveController(BallSpawner _ballSpawner)
            => _activBalls = _ballSpawner.Collection;

        public void RightAddForceBalls()
        {
            foreach (Ball ball in _activBalls)
                ball.Rigidbody2D.AddForceX(ADD_FORCE_POWER);
        }
        public void LeftAddForceBalls()
        {
            foreach (Ball ball in _activBalls)
                ball.Rigidbody2D.AddForceX(-ADD_FORCE_POWER);
        }
    }
}