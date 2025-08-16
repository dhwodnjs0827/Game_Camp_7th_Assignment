using UnityEngine;

public class Arrow : BaseSkill
{
    private void Update()
    {
        transform.position += new Vector3(0f, -2f * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(caster))
        {
            return;
        }
        var target = other.gameObject.GetComponent<IDamageable>();
        target?.TakeDamage(skillData.Damage);
        Destroy(gameObject);
    }
}