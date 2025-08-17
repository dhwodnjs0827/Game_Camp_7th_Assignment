using DataDeclaration;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupInfo : PopupUI
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image gradeColorImage;
    [SerializeField] private TextMeshProUGUI gradeText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI cooldownText;
    [SerializeField] private TextMeshProUGUI skillTypeText;
    [SerializeField] private TextMeshProUGUI attackTypeText;

    public override void Hide()
    {
        base.Hide();
        iconImage.sprite = null;
        nameText.text = null;
        gradeColorImage.sprite = null;
        gradeText.text = null;
        descriptionText.text = null;
        attackText.text = null;
        cooldownText.text = null;
        skillTypeText.text = null;
        attackTypeText.text = null;
    }

    public void SetData(SkillSO skill, SkillDataByGrade skillData)
    {
        iconImage.sprite = skill.Icon;
        nameText.text = skill.SkillName;
        gradeColorImage.color = GradeColor.GRADE_COLOR[skillData.Grade];
        gradeText.text = skillData.Grade.ToString();
        descriptionText.text = skill.Description;
        attackText.text = skillData.Damage.ToString("N");
        cooldownText.text = skillData.Cooldown.ToString("F");
        skillTypeText.text = skill.SkillType.ToString();
        attackTypeText.text = skill.AttackType.ToString();
    }
}
