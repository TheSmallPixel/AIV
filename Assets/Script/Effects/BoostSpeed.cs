using UnityEngine;

namespace Assets.Script.Effects
{
    [CreateAssetMenu(fileName = "Effects", menuName = "AIV/Effects/Boost")]
    public class BoostSpeed : Effect
    {
        public float Velocity;

        private float _oldVelocity;


        public override int Duration => 10;

        public override void AddEffect(Player stats)
        {
            _oldVelocity = stats.Velocity;
            stats.Velocity = Velocity;
        }

        public override void RemoveEffect(Player stats)
        {
            stats.Velocity = _oldVelocity;
        }
    }
}
