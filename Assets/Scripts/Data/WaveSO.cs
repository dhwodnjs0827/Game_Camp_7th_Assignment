using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Data/Wave")]
public class WaveSO : ScriptableObject
{
    public int Index;
    public float Duration;
    public List<MonsterSO> SpawnMonsters;
    public float SpawnRate;
    public int SpawnCount;
}
