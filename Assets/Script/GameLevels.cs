using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script
{
    [CreateAssetMenu(fileName = "game", menuName = "mygame/gameLevels")]
    public class GameLevels : ScriptableObject
    {
        public List<Level> Levels;
    }
}
