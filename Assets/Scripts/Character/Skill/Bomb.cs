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
        yield return new WaitForSeconds(SkillConstant.BOMB_EXPLODE_DELAY_TIME);
        animator.SetTrigger(BombExplode);
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, skillData.Range);
        for (int i = 0; i < hits.Length; i++)
        {
            if (!hits[i].gameObject.Equals(caster) && hits[i].TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(skillData.Damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Color color = Color.red;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, skillData.Range);
    }
}
