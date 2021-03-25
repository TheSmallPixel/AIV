using Assets.Script;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "mygame/level", order = 1)]
public class Level : ScriptableObject
{
    [Range(0, 20)]
    public int Count;

    public List<Effect> Objects;

    [Range(-10, 10)] public int PositionMin;
    [Range(-10, 10)] public int PositionMax;

}
