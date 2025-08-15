using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupInfo : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI cooldownText;
    [SerializeField] private TextMeshProUGUI skillTypeText;
    [SerializeField] private TextMeshProUGUI attackTypeText;

    private void OnDisable()
    {
        iconImage.sprite = null;
        nameText.text = null;
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
        descriptionText.text = skill.Description;
        attackText.text = skillData.Damage.ToString();
        cooldownText.text = skillData.Cooldown.ToString();
        skillTypeText.text = skill.SkillType.ToString();
        attackTypeText.text = skill.AttackType.ToString();
    }
}
