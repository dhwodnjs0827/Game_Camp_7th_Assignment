using DataDeclaration;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    private SkillDataByGrade skillData;
    private float skillCooldown;
    private int skillStack;
    
    [SerializeField] private Button button;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image gradeColor;
    [SerializeField] private Image coolDownImage;
    [SerializeField] private TextMeshProUGUI stackText;

    public void SetSkill(SkillSO data, SkillGrade grade)
    {
        skillData = data.SkillDatasByGrade[(int)grade];
        skillCooldown = skillData.Cooldown;
        skillStack = 0;

        iconImage.sprite = data.Icon;
        gradeColor.color = GradeColor.GradeColorDict[grade];
        coolDownImage.fillAmount = 0f;
        stackText.text = skillStack.ToString();
    }
}
