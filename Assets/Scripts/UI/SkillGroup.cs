using System.Collections.Generic;
using DataDeclaration;
using UnityEngine;

public class SkillGroup : MonoBehaviour
{
    [SerializeField] private Transform bombGroup;
    [SerializeField] private Transform plasmaGroup;
    [SerializeField] private Transform arrowGroup;

    private Dictionary<SkillType, SkillSlot[]> skillSlots;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        skillSlots = new Dictionary<SkillType, SkillSlot[]>();
        
        var skillDatas = Resources.LoadAll<SkillSO>("Data/SO/Skill");
        SkillSlot prefab = Resources.Load<SkillSlot>("Prefabs/UI/SkillSlot");
        for (int i = 0; i < skillDatas.Length; i++)
        {
            SkillSlot[] slots = new SkillSlot[6];
            SkillType type = skillDatas[i].SkillType;
            for (int j = 0; j < slots.Length; j++)
            {
                SkillSlot slot = null;
                if (type == SkillType.Bomb)
                {
                    slot = Instantiate(prefab, bombGroup);
                }
                else if (type == SkillType.Plasma)
                {
                    slot = Instantiate(prefab, plasmaGroup);
                }
                else if (type == SkillType.Arrow)
                {
                    slot = Instantiate(prefab, arrowGroup);
                }

                if (slot != null)
                {
                    slot.Init(skillDatas[i], j);
                    slot.OnSynthesizeSkill += SynthesizeSkill;
                    slots[j] = slot;
                }
            }
            skillSlots.Add(type, slots);
        }
    }

    public void GetNewSkill()
    {
        SkillType newSkillType = (SkillType)Random.Range(0, 3);
        skillSlots[newSkillType][0].IncreaseStack();
    }

    private void SynthesizeSkill(int materialGrade)
    {
        if (materialGrade == (int)SkillGrade.Mythic)
        {
            // 최고 등급 합성 시
            return;
        }
        int synthesizedGrade = materialGrade + 1;
        SkillType synthesizedSkillType = (SkillType)Random.Range(0, 3);
        skillSlots[synthesizedSkillType][synthesizedGrade].IncreaseStack();
    }
}
