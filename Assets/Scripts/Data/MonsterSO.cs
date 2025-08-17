using DataDeclaration;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster", menuName = "Data/Monster")]
public class MonsterSO : ScriptableObject
{
    public string ID;
    public string MonsterName;
    public string Description;
    public MonsterType Type;
    public float MaxHP;
    public float Attack;
    public int DropGold;
}
