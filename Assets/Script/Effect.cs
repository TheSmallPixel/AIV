using UnityEngine;

namespace Assets.Script
{

    public abstract class Effect : ScriptableObject
    {
        public abstract int Duration { get; }

        public abstract void AddEffect(SimplePlayer stats);

        public abstract void RemoveEffect(SimplePlayer stats);
    }

}
