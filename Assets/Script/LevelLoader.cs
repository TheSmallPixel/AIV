using UnityEngine;

namespace Assets.Script
{
    public class LevelLoader : MonoBehaviour
    {

        public static LevelLoader Singleton;



        [SerializeField] private Level _level;

        [SerializeField] private GameObject _EffectPrefab;

        void Awake()
        {
            Singleton = this;
        }

        void Start()
        {
            for (int i = 0; i < _level.Count; i++)
            {
                int index = Random.Range(0, _level.Objects.Count);
                float x = Random.Range(_level.PositionMin, _level.PositionMax);
                float y = Random.Range(_level.PositionMin, _level.PositionMax);

                var player = Instantiate(_EffectPrefab, new Vector3(x, y, 0), Quaternion.identity);
                player.GetComponent<GameObjectEffector>().Effect = _level.Objects[index];
            }
        }


        public void Respawn(GameObject obj)
        {
            float x = Random.Range(_level.PositionMin, _level.PositionMax);
            float y = Random.Range(_level.PositionMin, _level.PositionMax);

            obj.transform.localPosition = new Vector3(x, y, 0);
        }
    }
}
