using DataDeclaration;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, ISkill
{
    [SerializeField] protected SkillSO data;
    public SkillType SkillType => data.SkillType;
    public abstract void ExecuteSkill(SkillGrade grade);
}
