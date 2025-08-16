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
    [SerializeField] private Image synthesizeImage;

    [SerializeField] private Button skillButton;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image gradeColor;
    [SerializeField] private Image coolDownImage;
    [SerializeField] private TextMeshProUGUI stackText;

    public event Action<SkillSlot, SkillSO, SkillDataByGrade> OnPopupInfo;
    public event Action<int> OnSynthesizeSkill;
    public event Action<SkillType, SkillGrade> OnSkillReady;

    private void Awake()
    {
        skillButton.onClick.AddListener(OnClickSlotButton);
    }

    private void Update()
    {
        if (skillButton.gameObject.activeSelf)
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

    public void ActivateSynthesizeImage()
    {
        synthesizeImage.gameObject.SetActive(true);
    }

    public void DeactivateSynthesizeImage()
    {
        synthesizeImage.gameObject.SetActive(false);
    }

    private void DecreaseStack()
    {
        skillStack -= 3;
        if (skillStack <= 0)
        {
            DeactivateButton();
        }
    }

    private void OnClickSlotButton()
    {
        if (synthesizeImage.gameObject.activeSelf)
        {
            Synthesize();
        }
        else
        {
            OnPopupInfo?.Invoke(this, skillData, skillDataByGrade);
        }
    }

    private void Synthesize()
    {
        if (skillStack >= 3)
        {
            DecreaseStack();
            OnSynthesizeSkill?.Invoke((int)grade);
            synthesizeImage.gameObject.SetActive(false);
        }
    }

    private void ActivateButton()
    {
        skillButton.gameObject.SetActive(true);
    }

    private void DeactivateButton()
    {
        coolDownImage.fillAmount = 0f;
        skillButton.gameObject.SetActive(false);
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
            currentCooldown = 0f;
            OnSkillReady?.Invoke(skillData.SkillType, grade);
        }
    }
}