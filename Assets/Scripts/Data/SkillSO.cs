using System;
using UnityEngine;

public enum AttackType
{
    Melee,
    Ranged,
}

public enum AttackTargetType
{
    Area,
    Single,
}

public enum SkillType
{
    Bomb, // 근거리 범위
    Plasma, // 원거리 범위
    Arrow, // 원거리 단일
}

public enum SkillGrade
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythic,
}

[Serializable]
public class SkillDataByGrade
{
    public float Damage;
    public float Cooldown;
    public SkillGrade Grade;
}

[CreateAssetMenu(fileName = "Skill", menuName = "Data/Skill")]
public class SkillSO : ScriptableObject
{
    public string SkillName;
    public string Description;
    public SkillType SkillType;
    public AttackType AttackType;
    public AttackTargetType AttackTargetType;
    public SkillDataByGrade[] SkillDatasByGrade = new SkillDataByGrade[6];
}
