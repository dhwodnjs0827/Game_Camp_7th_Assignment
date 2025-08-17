using System;
using DataDeclaration;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : ScreenUI
{
    [SerializeField] private TextMeshProUGUI waveInfoText;
    [SerializeField] private TextMeshProUGUI playerGoldText;
    
    [SerializeField] private Button gameSpeedButton;
    [SerializeField] private TextMeshProUGUI gameSpeedText;
    private float[] gameSpeedArray;
    private int gameSpeedIndex;
    private float gameSpeed;
    
    
    [SerializeField] private SkillGroup skillGroup;
    
    [SerializeField] private Button createSkillButton;
    [SerializeField] private TextMeshProUGUI skillGoldText;
    private int skillGold;
    
    public SkillGroup SkillGroup => skillGroup;
    
    public event Action OnClickCreateSkill;

    protected override void Init()
    {
        base.Init();
        createSkillButton.onClick.AddListener(OnClickCreateSkillButton);
        gameSpeedButton.onClick.AddListener(OnClickGameSpeedButton);
        gameSpeedArray = GameConstant.GAME_SPEED_LIST;
        gameSpeedIndex = 0;
        gameSpeed = gameSpeedArray[gameSpeedIndex];

        skillGold = GameConstant.INIT_SKILL_GOLD;
        skillGoldText.text = skillGold.ToString("N0");

        playerGoldText.text = $"골드: {GameManager.Instance.Gold:N0}";
        
        OnClickCreateSkill += skillGroup.GetNewSkill;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnChangeGold += ChangeGold;
        }
    }

    private void Update()
    {
        UpdateWaveInfo();
    }

    private void OnDisable()
    {
        OnClickCreateSkill -= skillGroup.GetNewSkill;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnChangeGold -= ChangeGold;
        }
    }

    private void OnClickCreateSkillButton()
    {
        if (skillGold <= GameManager.Instance.Gold)
        {
            OnClickCreateSkill?.Invoke();
            GameManager.Instance.DecreaseGold(skillGold);
            skillGold++;
            skillGoldText.text = skillGold.ToString("N0");
        }
    }

    private void OnClickGameSpeedButton()
    {
        ChangeGameSpeed();
        gameSpeedText.text = $"게임 속도\nX {gameSpeed:F1}";
    }
    
    private void UpdateWaveInfo()
    {
        waveInfoText.text = $"웨이브 {GameManager.Instance.CurrentWaveIndex}\n{TimeFormatUtility.ToMinuteSecond(GameManager.Instance.WaveTimer)}";
    }
    
    private void ChangeGameSpeed()
    {
        gameSpeedIndex = (gameSpeedIndex + 1) % gameSpeedArray.Length;
        gameSpeed = gameSpeedArray[gameSpeedIndex];
        Time.timeScale = gameSpeed;
    }

    private void ChangeGold()
    {
        playerGoldText.text = $"골드: {GameManager.Instance.Gold:N0}";
    }
}
