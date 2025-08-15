using DataDeclaration;
using UnityEngine;

public class Plasma : BaseSkill
{
    private float damage;

    private void Update()
    {
        transform.position += new Vector3(0f, -2f * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var target = other.gameObject.GetComponent<IDamageable>();
        target?.TakeDamage(damage);
    }

    public override void ExecuteSkill(SkillGrade grade)
    {
        damage = data.SkillDatasByGrade[(int)grade].Damage;
    }
}
