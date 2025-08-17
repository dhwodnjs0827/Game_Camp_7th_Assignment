using UnityEngine;
using UnityEngine.UI;

public class MonsterStatController : MonoBehaviour
{
    [SerializeField] private Image currentHPBar;
    [SerializeField] private Transform damageTextPoint;

    private float maxHP;
    private float currentHP;
    private float attack;
    
    public float CurrentHP => currentHP;
    public float Attack => attack;

    public void InitStats(MonsterSO data)
    {
        maxHP = data.MaxHP;
        currentHP = maxHP;
        attack = data.Attack;
    }

    private void Update()
    {
        currentHPBar.fillAmount = currentHP / maxHP;
    }

    public void Damaged(float damage)
    {
        currentHP -= damage;
        currentHPBar.fillAmount = currentHP / maxHP;
        CreateDamageText(damage);
    }

    private void CreateDamageText(float damage)
    {
        var prefab = Resources.Load<DamageText>("Prefabs/UI/DamageText");
        var damageText = Instantiate(prefab, damageTextPoint);
        damageText.Init(damage);
    }
}
