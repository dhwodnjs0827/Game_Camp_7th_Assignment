using System;
using System.Collections;
using DataDeclaration;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private Transform playerRespawnPoint;

    #region GameLogicFields

    public bool IsGameOver = false;
    
    private WaveSO[] waves;
    private WaveSO currentWave;
    private bool canSpawn;
    private float waveTimer;
    private float waveCooldown;
    private int currentWaveIndex;

    private int gold;
    
    public float WaveTimer => waveTimer;
    public int CurrentWaveIndex => currentWaveIndex;
    public int Gold => gold;
    public event Action<MonsterSO> OnRespawnMonster;
    public event Action OnChangeGold;

    #endregion

    protected override void Awake()
    {
        base.Awake();
        GameLogicSetting();
        UIManager.Instance.CreateUI<MainUI>();
        RespawnPlayer();
    }
    
#if UNITY_EDITOR
    public void OnClickStartWaveButton()
    {
        canSpawn = true;
    }
#else
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(GameConstant.INIT_DELAY_WAVE_TIME);
        canSpawn = true;
    }
#endif

    private void Update()
    {
        if (IsGameOver)
        {
            return;
        }
        if (!canSpawn)
        {
            return;
        }

        StartWave();
    }

    private void RespawnPlayer()
    {
        Player prefab = Resources.Load<Player>("Prefabs/Player");
        Instantiate(prefab, playerRespawnPoint.position, Quaternion.identity);
    }

    private void GameLogicSetting()
    {
        waves = Resources.LoadAll<WaveSO>("Data/SO/Wave");
        canSpawn = false;
        currentWaveIndex = 0;

        gold = GameConstant.INIT_GOLD;
    }
    
    private void StartWave()
    {
        if (waveTimer <= 0)
        {
            if (currentWaveIndex >= waves.Length)
            {
                IsGameOver = true;
                return;
            }
            currentWave = waves[currentWaveIndex];
            waveTimer = currentWave.Duration;
            currentWaveIndex++;
        }
        else
        {
            waveTimer -= Time.deltaTime;
            if (waveCooldown <= 0)
            {
                OnRespawnMonster?.Invoke(currentWave.SpawnMonster);
                waveCooldown = currentWave.SpawnRate;
            }
            else
            {
                waveCooldown -= Time.deltaTime;
            }
        }
    }

    public void IncreaseGold(int amount)
    {
        gold += amount;
        OnChangeGold?.Invoke();
    }

    public void DecreaseGold(int amount)
    {
        gold -= amount;
        OnChangeGold?.Invoke();
    }
}