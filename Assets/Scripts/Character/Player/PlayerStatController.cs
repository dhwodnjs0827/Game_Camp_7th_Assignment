using DataDeclaration;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatController : MonoBehaviour
{
    [SerializeField] private GameObject statCanvas;
    [SerializeField] private Image currentHPBar;
    private float currentHP;
    
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = PlayerConstant.MaxHP;
        currentHPBar.fillAmount = currentHP / PlayerConstant.MaxHP;
    }

    private void OnEnable()
    {
        statCanvas.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        statCanvas.gameObject.SetActive(false);
    }

    public void Damaged(float damage)
    {
        currentHP -= damage;
        currentHPBar.fillAmount = currentHP / PlayerConstant.MaxHP;
    }
}