using DataDeclaration;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatController : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    private float currentHP;
    
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = PlayerConstant.MaxHP;
        hpBar.fillAmount = currentHP / PlayerConstant.MaxHP;
    }

    public void Damaged(float damage)
    {
        currentHP -= damage;
        hpBar.fillAmount = currentHP / PlayerConstant.MaxHP;
    }
}