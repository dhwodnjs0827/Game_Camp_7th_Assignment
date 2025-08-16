using System.Collections;
using DataDeclaration;
using UnityEngine;

public class Bomb : BaseSkill
{
    private static readonly int BombExplode = Animator.StringToHash("Explode");
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void ExecuteSkill(SkillGrade grade, GameObject caster)
    {
        base.ExecuteSkill(grade, caster);
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);
        animator.SetTrigger(BombExplode);
        Collider2D[] hits = Physics2D.OverlapCircleAll(Vector2.zero, skillData.Range);
        for (int i = 0; i < hits.Length; i++)
        {
            if (!hits[i].gameObject.Equals(caster) && hits[i].TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(skillData.Damage);
            }
        }
    }
}
