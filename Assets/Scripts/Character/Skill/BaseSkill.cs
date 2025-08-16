using DataDeclaration;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, ISkill
{
    [SerializeField] protected SkillSO skillSO;
    protected SkillDataByGrade skillData;
    protected GameObject caster;
    
    public SkillType SkillType => skillSO.SkillType;

    public virtual void ExecuteSkill(SkillGrade grade, GameObject caster)
    {
        skillData = skillSO.SkillDatasByGrade[(int)grade];
        this.caster = caster;
    }
}
