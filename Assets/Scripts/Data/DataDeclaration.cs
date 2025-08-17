using System.Collections.Generic;
using UnityEngine;

namespace DataDeclaration
{
    #region Constants

    public static class GameConstant
    {
        public const int INIT_GOLD = 100;
        public const float INIT_DELAY_WAVE_TIME = 5f;
        public const int INIT_MONSTER_POOL_STACK = 20;
        public const int SYNTHESIZE_STACK = 3;
        public static readonly float[] GAME_SPEED_LIST = new float[4] { 1f, 2f, 3f, 5f };
        public const float DAMAGE_TEXT_DURATION = 0.5f;
        public const float DAMAGE_TEXT_SPEED = 2f;
    }
    
    public static class PlayerConstant
    {
        public const float MAX_HP = 100f;
    }

    public static class MonsterConstant
    {
        public const float MOVE_SPEED = 1.5f;
        public const float ATTACK_SPEED = 1.3f;
    }

    public static class SkillConstant
    {
        public const float PROJECTILE_SPEED = 2f;
        public const float BOMB_EXPLODE_DELAY_TIME = 2f;
    }

    public static class GradeColor
    {
        public static readonly Dictionary<SkillGrade, Color> GRADE_COLOR = new Dictionary<SkillGrade, Color>()
        {
            { SkillGrade.Common, new Color(128/255f, 128/255f, 128/255f) },
            { SkillGrade.Uncommon, new Color(20/255f, 94/255f, 0f) },
            { SkillGrade.Rare, new Color(0f, 48/255f, 103/255f)},
            { SkillGrade.Epic, new Color(77f/255f, 0f, 111/255f) },
            { SkillGrade.Legendary, new Color(137/255f, 119/255f, 0f) },
            { SkillGrade.Mythic, new Color(176f/255f, 13/255f, 0f) }
        };
    }

    #endregion

    #region Enum

    public enum MonsterType
    {
        Normal,
        Elite,
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

    #endregion
}