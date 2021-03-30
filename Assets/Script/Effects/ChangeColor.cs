using UnityEngine;

namespace Assets.Script.Effects
{
    [CreateAssetMenu(fileName = "Effects", menuName = "AIV/Effects/ChangeColor")]
    public class ChangeColor : Effect
    {
        public Color Color;
        private Color _old;


        public override int Duration => 5;

        public override void AddEffect(SimplePlayer stats)
        {
            var render = stats.GetComponent<SpriteRenderer>();
            if (render != null)
            {
                _old = render.color;
                render.color = Color;
            }
        }

        public override void RemoveEffect(SimplePlayer stats)
        {
            var render = stats.GetComponent<SpriteRenderer>();
            if (render != null)
            {
                render.color = _old;
            }
        }
    }
}
