using DataDeclaration;
using UnityEngine;

public class Bomb : BaseSkill
{
    public override void ExecuteSkill(SkillGrade grade)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(Vector2.zero, 5f);
        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable hitTarget = hits[i].GetComponent<IDamageable>();
            hitTarget?.TakeDamage(data.SkillDatasByGrade[(int)grade].Damage);
        }
    }
}
