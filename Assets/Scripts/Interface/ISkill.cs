using DataDeclaration;
using UnityEngine;

public interface ISkill
{
    public void ExecuteSkill(SkillGrade grade, GameObject caster);
}
