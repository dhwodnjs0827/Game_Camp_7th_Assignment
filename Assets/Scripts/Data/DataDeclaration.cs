using System.Collections.Generic;
using UnityEngine;

namespace DataDeclaration
{
    public static class PlayerConstant
    {
        public const float MaxHP = 100f;
    }

    public static class MonsterConstant
    {
        public const float MoveSpeed = 1.5f;
        public const float AttackSpeed = 1.3f;
    }

    public static class GradeColor
    {
        public static readonly Dictionary<SkillGrade, Color> GradeColorDict = new Dictionary<SkillGrade, Color>()
        {
            { SkillGrade.Common, new Color(128/255f, 128/255f, 128/255f) },
            { SkillGrade.Uncommon, new Color(20/255f, 94/255f, 0f) },
            { SkillGrade.Rare, new Color(0f, 48/255f, 103/255f)},
            { SkillGrade.Epic, new Color(77f/255f, 0f, 111/255f) },
            { SkillGrade.Legendary, new Color(137/255f, 119/255f, 0f) },
            { SkillGrade.Mythic, new Color(176f/255f, 13/255f, 0f) }
        };
    }
    
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
}