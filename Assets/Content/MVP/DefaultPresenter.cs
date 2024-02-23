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
            PlayController playController, ProgressManager progressManager) 
            : base(model, view, audioSystem, timeIndication,  ballSpawner, ballMoveController, 
                  portalsTransformController, takedEffectSpawner, playController, progressManager)
        {
            _chanceOfAppaearance = new Dictionary<TakedEffectTypes, double> 
            { 
                { TakedEffectTypes.Bomb, 70 },
                { TakedEffectTypes.IncreaseScale, 2 },
                { TakedEffectTypes.IncreaseVelocity, 2 },
                { TakedEffectTypes.ReduceScale, 1},
                { TakedEffectTypes.ReduceVelocity, 1},
                { TakedEffectTypes.SpawnBall, 2 },
                { TakedEffectTypes.Star, 20 },
                { TakedEffectTypes.SwapGravity, 2 }
            };
        }

        protected override TakedEffectTypes GetRandomTypeEffectInPlay()
        {
            Random random = new Random();
            return random.Pick(_chanceOfAppaearance);
        }
    }
}