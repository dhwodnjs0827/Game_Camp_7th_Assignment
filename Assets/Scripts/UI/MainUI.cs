using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveInfoText;
    [SerializeField] private TextMeshProUGUI resourceInfoText;
    [SerializeField] private Button gameSpeedButton;
    [SerializeField] private TextMeshProUGUI gameSpeedText;
    [SerializeField] private Button createSkillButton;
    [SerializeField] private SkillGroup skillGroup;
    
    [SerializeField] private MonsterSpawner monsterSpawner;
    
    public SkillGroup SkillGroup => skillGroup;
    
    public event Action OnClickCreateSkill;

    private void Awake()
    {
        createSkillButton.onClick.AddListener(OnClickCreateSkillButton);
        gameSpeedButton.onClick.AddListener(OnClickGameSpeedButton);
    }

    private void OnEnable()
    {
        OnClickCreateSkill += skillGroup.GetNewSkill;
    }

    private void Update()
    {
        UpdateWaveInfo();
    }

    private void OnDisable()
    {
        OnClickCreateSkill -= skillGroup.GetNewSkill;
    }

    private void OnClickCreateSkillButton()
    {
        OnClickCreateSkill?.Invoke();
    }

    private void OnClickGameSpeedButton()
    {
        GameManager.Instance.ChangeGameSpeed();
        gameSpeedText.text = $"게임 속도\nX {GameManager.Instance.GameSpeed:F1}";

    }
    
    private void UpdateWaveInfo()
    {
        waveInfoText.text = $"웨이브 {monsterSpawner.CurrentWaveIndex}\n{TimeFormatUtility.ToMinuteSecond(monsterSpawner.WaveTimer)}";
    }
}
