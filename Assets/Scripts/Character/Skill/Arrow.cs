using DataDeclaration;
using UnityEngine;

public class Arrow : BaseSkill
{
    private bool hasHit;

    private void Awake()
    {
        hasHit = false;
    }

    private void Update()
    {
        if (!hasHit)
        {
            transform.position += new Vector3(0f, -SkillConstant.PROJECTILE_SPEED * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit)
        {
            return;
        }
        if (other.gameObject.Equals(caster))
        {
            return;
        }
        hasHit = true;
        var target = other.gameObject.GetComponent<IDamageable>();
        target?.TakeDamage(skillData.Damage);
        Destroy(gameObject);
    }
}