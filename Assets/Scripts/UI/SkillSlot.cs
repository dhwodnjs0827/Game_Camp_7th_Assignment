using System;
using DataDeclaration;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    private SkillSO skillData;
    private SkillDataByGrade skillDataByGrade;
    private SkillGrade grade;
    private int skillStack;
    
    private float skillCooldown;
    private float currentCooldown;
    private float fillAmountSpeed;

    [SerializeField] private Image backgroundIcon;

    [SerializeField] private Button button;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image gradeColor;
    [SerializeField] private Image coolDownImage;
    [SerializeField] private TextMeshProUGUI stackText;

    public event Action<int> OnSynthesizeSkill;

    private void Awake()
    {
        button.onClick.AddListener(OnClickButton);
    }

    private void Update()
    {
        if (button.gameObject.activeSelf)
        {
            UpdateUI();
        }
    }

    public void Init(SkillSO data, int index)
    {
        skillData = data;
        grade = (SkillGrade)index;
        skillDataByGrade = data.SkillDatasByGrade[index];
        backgroundIcon.sprite = data.Icon;

        iconImage.sprite = data.Icon;
        gradeColor.color = GradeColor.GradeColorDict[grade];

        DeactivateButton();
    }

    public void IncreaseStack()
    {
        if (skillStack == 0)
        {
            ActivateButton();
        }
        skillStack++;
    }

    private void DecreaseStack()
    {
        skillStack -= 3;
        if (skillStack <= 0)
        {
            DeactivateButton();
        }
    }

    private void OnClickButton()
    {
        if (skillStack >= 3)
        {
            DecreaseStack();
            OnSynthesizeSkill?.Invoke((int)grade);
        }
    }

    private void OnPointerDownButton()
    {
        // PopupInfo 활성화
    }

    private void ActivateButton()
    {
        button.gameObject.SetActive(true);
    }

    private void DeactivateButton()
    {
        coolDownImage.fillAmount = 0f;
        button.gameObject.SetActive(false);
    }

    private void UpdateUI()
    {
        skillCooldown = skillDataByGrade.Cooldown / skillStack;
        currentCooldown += Time.deltaTime;
        stackText.text = skillStack.ToString();
        coolDownImage.fillAmount = currentCooldown / skillCooldown;
        ActiveSkill();
    }

    private void ActiveSkill()
    {
        if (coolDownImage.fillAmount >= 1f)
        {
            Debug.Log("스킬 사용");
            currentCooldown = 0f;
        }
    }
}