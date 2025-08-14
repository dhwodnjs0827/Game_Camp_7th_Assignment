using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    private WaveSO[] waves;
    private WaveSO currentWave;
    private float waveTimer;
    private float waveCooldown;
    private int currentWaveIndex;
    private Queue<Monster> monsterPool;

    protected void Awake()
    {
        waves = Resources.LoadAll<WaveSO>("Data/SO/Wave");
        currentWaveIndex = 0;
        InitMonsterPool();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
    }

    private void Update()
    {
        if (waveTimer <= 0)
        {
            StartWave();
        }
        else
        {
            waveTimer -= Time.deltaTime;
            if (waveCooldown <= 0)
            {
                RespawnMonster(currentWave.SpawnMonsters[0]);
            }
            else
            {
                waveCooldown -= Time.deltaTime;
            }
        }
    }

    private void StartWave()
    {
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
        monster.transform.position = respawnPoint.position;

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
