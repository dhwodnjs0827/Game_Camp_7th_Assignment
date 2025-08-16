using System;
using DataDeclaration;
using UnityEngine;

[Serializable]
public class SkillDataByGrade
{
    public float Damage;
    public float Cooldown;
    public float Range;
}

[CreateAssetMenu(fileName = "Skill", menuName = "Data/Skill")]
public class SkillSO : ScriptableObject
{
    public string SkillName;
    public string Description;
    public Sprite Icon;
    public SkillType SkillType;
    public AttackType AttackType;
    public AttackTargetType AttackTargetType;
    public SkillDataByGrade[] SkillDatasByGrade = new SkillDataByGrade[6];
}
