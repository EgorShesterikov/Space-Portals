using System;
using System.Collections.Generic;
using System.Linq;

namespace SpacePortals
{
    public static class RandomPickInDictionary
    {
        public static T Pick<T>(this Random random, Dictionary<T, double> elementToProbability)
        {
            var totalProbability = elementToProbability.Values.Sum();
            var randomValue = random.NextDouble() * totalProbability;

            foreach (var keyValuePair in elementToProbability)
            {
                if (randomValue < keyValuePair.Value)
                    return keyValuePair.Key;

                randomValue -= keyValuePair.Value;
            }
            return default(T);
        }
    }
}