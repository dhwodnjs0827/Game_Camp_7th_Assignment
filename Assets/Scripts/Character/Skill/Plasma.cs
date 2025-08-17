using DataDeclaration;
using UnityEngine;

public class Plasma : BaseSkill
{
    private void Update()
    {
        transform.position += new Vector3(0f, -SkillConstant.PROJECTILE_SPEED * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(caster))
        {
            return;
        }
        Explode(other.ClosestPoint(transform.position));
    }
    
    private void Explode(Vector2 hitPoint)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(hitPoint, skillData.Range);
        for (int i = 0; i < hits.Length; i++)
        {
            if (!hits[i].gameObject.Equals(caster) && hits[i].TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(skillData.Damage);
            }
        }
        Destroy(gameObject);
    }
    
    private void OnDrawGizmos()
    {
        Color color = Color.red;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, skillData.Range);
    }
}