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
            PlayController playController, ProgressManager progressManager, GlobalSFXSource globalSFXSource, Tutorial tutorial) 
            : base(model, view, audioSystem, timeIndication,  ballSpawner, ballMoveController, 
                  portalsTransformController, takedEffectSpawner, playController, progressManager, globalSFXSource, tutorial)
        {
            _chanceOfAppaearance = new Dictionary<TakedEffectTypes, double> 
            { 
                { TakedEffectTypes.Bomb, 55 },
                { TakedEffectTypes.IncreaseScale, 5 },
                { TakedEffectTypes.IncreaseVelocity, 5 },
                { TakedEffectTypes.ReduceScale, 2.5},
                { TakedEffectTypes.ReduceVelocity, 2.5},
                { TakedEffectTypes.SpawnBall, 5 },
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