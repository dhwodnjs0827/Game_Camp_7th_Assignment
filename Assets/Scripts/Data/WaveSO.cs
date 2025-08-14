using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Data/Wave")]
public class WaveSO : ScriptableObject
{
    public int Index;
    public float Duration;
    public MonsterSO SpawnMonster;
    public float SpawnRate;
    public int SpawnCount;
}
