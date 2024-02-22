using System.Collections.Generic;
using UnityEngine;

namespace SpacePortals
{
    [CreateAssetMenu(fileName = "TakeEffectFactoryConfig", menuName = "Factory/TakeEffectFactoryConfig")]
    public class TakedEffectFactoryConfig : ScriptableObject
    {
        [SerializeField] private List<TakeEffectConfig> _takeEffectCollection;

        public TakedEffect FindTypeEffect(TakedEffectTypes type)
        {
            TakedEffect effect = _takeEffectCollection.Find(effect => effect.Tupe == type).Effect;

            if (effect == null)
                throw new System.ArgumentNullException(nameof(effect));

            return effect;
        }

        [System.Serializable]
        private struct TakeEffectConfig
        {
            public TakedEffectTypes Tupe;
            public TakedEffect Effect;
        }
    }
}