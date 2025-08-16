using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Transform playerRespawnPoint;
    [SerializeField] private Transform monsterRespawnPoint;

    private WaveSO[] waves;
    private WaveSO currentWave;
    private float startDelay;
    private bool canSpawn;
    private float waveTimer;
    private float waveCooldown;
    private int currentWaveIndex;
    private Queue<Monster> monsterPool;
    
    public float WaveTimer => waveTimer;
    public int CurrentWaveIndex => currentWaveIndex;

    private void Awake()
    {
        waves = Resources.LoadAll<WaveSO>("Data/SO/Wave");
        startDelay = 5f;
        canSpawn = false;
        currentWaveIndex = 0;
        InitMonsterPool();
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
                RespawnMonster(currentWave.SpawnMonster);
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
        Instantiate(prefab, playerRespawnPoint.position, Quaternion.identity);
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

    private void RespawnMonster(MonsterSO data)
    {
        monsterPool.TryDequeue(out Monster monster);
        if (monster == null)
        {
            var prefab = Resources.Load<Monster>("Prefabs/Monster/NormalMonster");
            monster = Instantiate(prefab);
        }
        else
        {
            monster.gameObject.SetActive(true);
        }

        monster.SetMonsterData(data);
        monster.transform.position = monsterRespawnPoint.position;

        waveCooldown = currentWave.SpawnRate;
    }

    private void InitMonsterPool()
    {
        monsterPool = new Queue<Monster>();
        var prefab = Resources.Load<Monster>("Prefabs/Monster/NormalMonster");
        for (int i = 0; i < 20; i++)
        {
            Monster monster = Instantiate(prefab);
            monster.gameObject.SetActive(false);
            monsterPool.Enqueue(monster);
        }
    }
}
