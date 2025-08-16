using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveInfoText;
    [SerializeField] private TextMeshProUGUI resourceInfoText;
    [SerializeField] private Button createSkillButton;
    [SerializeField] private SkillGroup skillGroup;
    
    [SerializeField] private MonsterSpawner monsterSpawner;

    private void Awake()
    {
        createSkillButton.onClick.AddListener(OnClickCreateSkillButton);
    }

    private void Update()
    {
        UpdateWaveInfo();
    }

    private void OnClickCreateSkillButton()
    {
        skillGroup.GetNewSkill();
        GameManager.Instance.Player.StartAttack();
    }

    private void UpdateWaveInfo()
    {
        waveInfoText.text = $"웨이브 {monsterSpawner.CurrentWaveIndex}\n{TimeFormatUtility.ToMinuteSecond(monsterSpawner.WaveTimer)}";
    }
}
