using DataDeclaration;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    private SkillSO skillData;
    private SkillGrade grade;
    
    [SerializeField] private Image backgroundIcon;
    [SerializeField] private SkillButton button;

    public void Init(SkillSO data, int index)
    {
        skillData = data;
        grade = (SkillGrade)index;
        backgroundIcon.sprite = data.Icon;
        
        button.SetSkill(data, grade);
    }
}
