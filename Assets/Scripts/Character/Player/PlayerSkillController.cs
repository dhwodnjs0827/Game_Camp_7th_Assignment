using System.Collections.Generic;
using DataDeclaration;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    private Dictionary<SkillType, BaseSkill> skillPrefabs;

    [SerializeField] private Transform skillPoint;

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        // 임시 코드
        foreach (var slot in FindObjectsOfType<SkillSlot>())
        {
            slot.OnSkillReady += UseSkill;
        }
    }

    private void UseSkill(SkillType type, SkillGrade grade)
    {
        BaseSkill prefab = skillPrefabs[type];
        BaseSkill skillObject = Instantiate(prefab, skillPoint);
        ISkill iSkill = skillObject.GetComponent<ISkill>();
        iSkill.ExecuteSkill(grade, gameObject);
    }

    private void Init()
    {
        skillPrefabs = new Dictionary<SkillType, BaseSkill>();
        var skills = Resources.LoadAll<BaseSkill>("Prefabs/Skill");
        for (int i = 0; i < skills.Length; i++)
        {
            skillPrefabs.Add(skills[i].SkillType, skills[i]);
        }
    }
}