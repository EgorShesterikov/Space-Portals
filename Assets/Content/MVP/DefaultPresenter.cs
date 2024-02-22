using System;
using System.Collections.Generic;

namespace SpacePortals
{
    public class DefaultPresenter : Presenter
    {
        private Dictionary<TakedEffectTypes, double> _chanceOfAppaearance;

        public DefaultPresenter(Model model, View view, 
            AudioSystem audioSystem, TimeIndication timeIndication, 
            BallSpawner ballSpawner, BallMoveController ballMoveController, 
            PortalsTransformController portalsTransformController, TakedEffectSpawner takedEffectSpawner,
            PlayController playController) 
            : base(model, view, audioSystem, timeIndication, ballSpawner, ballMoveController, portalsTransformController, takedEffectSpawner, playController)
        {
            _chanceOfAppaearance = new Dictionary<TakedEffectTypes, double> 
            { 
                { TakedEffectTypes.Bomb, 40 },
                { TakedEffectTypes.IncreaseScale, 7.5 },
                { TakedEffectTypes.IncreaseVelocity, 7.5 },
                { TakedEffectTypes.ReduceScale, 5},
                { TakedEffectTypes.ReduceVelocity, 5},
                { TakedEffectTypes.SpawnBall, 10 },
                { TakedEffectTypes.Star, 20 },
                { TakedEffectTypes.SwapGravity, 5 }
            };
        }

        protected override TakedEffectTypes GetRandomTypeEffectInPlay()
        {
            Random random = new Random();
            return random.Pick(_chanceOfAppaearance);
        }
    }
}