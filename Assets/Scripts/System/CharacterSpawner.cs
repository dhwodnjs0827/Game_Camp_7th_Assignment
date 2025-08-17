using System.Collections.Generic;
using DataDeclaration;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Transform monsterRespawnPoint;
    private Queue<Monster> monsterPool;

    private void Awake()
    {
        InitMonsterPool();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnRespawnMonster += RespawnMonster;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnRespawnMonster -= RespawnMonster;
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
    }

    private void InitMonsterPool()
    {
        monsterPool = new Queue<Monster>();
        var prefab = Resources.Load<Monster>("Prefabs/Monster/NormalMonster");
        for (int i = 0; i < GameConstant.INIT_MONSTER_POOL_STACK; i++)
        {
            Monster monster = Instantiate(prefab);
            monster.gameObject.SetActive(false);
            monsterPool.Enqueue(monster);
        }
    }
}
