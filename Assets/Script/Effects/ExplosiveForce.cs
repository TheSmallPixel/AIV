using System.Collections;
using UnityEngine;

namespace Assets.Script.Effects
{
    [CreateAssetMenu(fileName = "Effects", menuName = "AIV/Effects/ExplosiveForce")]
    public class ExplosiveForce : Effect
    {
        [Range(0f, 10f)]
        public float MinForce;
        [Range(0f, 10f)]
        public float MaxForce;

        public override int Duration => 0;

        public override void AddEffect(SimplePlayer player)
        {
            player.StartCoroutine(StartTurbolence(player));
        }

        public override void RemoveEffect(SimplePlayer player)
        {

        }


        IEnumerator StartTurbolence(SimplePlayer player)
        {
            for (int i = 0; i < 40; i++)
            {
                float x = UnityEngine.Random.Range(MinForce, MaxForce);
                float y = UnityEngine.Random.Range(MinForce, MaxForce);
                player.transform.localPosition +=
                    new Vector3(Mathf.Sin(Time.time) * x * Time.deltaTime, Mathf.Cos(Time.time) * y * Time.deltaTime, 0);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
