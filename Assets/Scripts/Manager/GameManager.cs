using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Player player;
    
    [SerializeField] private Transform playerRespawnPoint;
    
    private MainUI mainUI;
    public MainUI MainUI => mainUI;
    
    
    private WaveSO[] waves;
    private WaveSO currentWave;
    private float startDelay;
    private bool canSpawn;
    private float waveTimer;
    private float waveCooldown;
    private int currentWaveIndex;
    public float WaveTimer => waveTimer;
    public int CurrentWaveIndex => currentWaveIndex;
    public event Action<MonsterSO> OnRespawnMonster;

    protected override void Awake()
    {
        base.Awake();
        WaveSetting();
        mainUI = UIManager.Instance.CreateUI<MainUI>();
        RespawnPlayer();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(startDelay);
        canSpawn = true;
    }

    private void Update()
    {
        if (!canSpawn)
        {
            return;
        }
        if (waveTimer <= 0)
        {
            StartWave();
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

    private void RespawnPlayer()
    {
        Player prefab = Resources.Load<Player>("Prefabs/Player");
        player = Instantiate(prefab, playerRespawnPoint.position, Quaternion.identity);
    }

    private void WaveSetting()
    {
        waves = Resources.LoadAll<WaveSO>("Data/SO/Wave");
        startDelay = 5f;
        canSpawn = false;
        currentWaveIndex = 0;
    }
    
    private void StartWave()
    {
        if (currentWaveIndex >= waves.Length)
        {
            return;
        }
        currentWave = waves[currentWaveIndex];
        waveTimer = currentWave.Duration;
        currentWaveIndex++;
    }
}