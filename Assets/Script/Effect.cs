using UnityEngine;

namespace Assets.Script
{

    public abstract class Effect : ScriptableObject
    {
        public abstract int Duration { get; }

        public abstract void AddEffect(Player stats);

        public abstract void RemoveEffect(Player stats);
    }

}
