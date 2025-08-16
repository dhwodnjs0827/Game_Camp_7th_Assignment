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
    private float[] gameSpeedArray;
    private int gameSpeedIndex;
    private float gameSpeed;
    
    [SerializeField] private SkillGroup skillGroup;
    
    [SerializeField] private Button createSkillButton;
    
    [SerializeField] private CharacterSpawner characterSpawner;
    
    public SkillGroup SkillGroup => skillGroup;
    
    public event Action OnClickCreateSkill;

    private void Awake()
    {
        createSkillButton.onClick.AddListener(OnClickCreateSkillButton);
        gameSpeedButton.onClick.AddListener(OnClickGameSpeedButton);
        gameSpeedArray = new float[4] { 1f, 2f, 3f, 5f };
        gameSpeedIndex = 0;
        gameSpeed = gameSpeedArray[gameSpeedIndex];
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
        ChangeGameSpeed();
        gameSpeedText.text = $"게임 속도\nX {gameSpeed:F1}";

    }
    
    private void UpdateWaveInfo()
    {
        waveInfoText.text = $"웨이브 {characterSpawner.CurrentWaveIndex}\n{TimeFormatUtility.ToMinuteSecond(characterSpawner.WaveTimer)}";
    }
    
    private void ChangeGameSpeed()
    {
        gameSpeedIndex = (gameSpeedIndex + 1) % gameSpeedArray.Length;
        gameSpeed = gameSpeedArray[gameSpeedIndex];
        Time.timeScale = gameSpeed;
    }
}
