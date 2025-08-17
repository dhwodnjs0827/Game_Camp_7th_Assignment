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
    
    private void InitMonsterPool()
    {
        monsterPool = new Queue<Monster>();
        var prefab = Resources.Load<Monster>("Prefabs/Monster/NormalMonster");
        for (int i = 0; i < GameConstant.INIT_MONSTER_POOL_STACK; i++)
        {
            Monster monster = Instantiate(prefab);
            monster.gameObject.SetActive(false);
            monster.OnReturnToPool += ReturnMonsterToPool;
            monsterPool.Enqueue(monster);
        }
    }

    private void RespawnMonster(MonsterSO data)
    {
        Monster monster = GetMonsterFromPool();
        monster.SetMonsterData(data);
        monster.transform.position = monsterRespawnPoint.position;
    }

    private Monster GetMonsterFromPool()
    {
        Monster monster;
        if (monsterPool.Count > 0)
        {
            monsterPool.TryDequeue(out monster);
            monster.gameObject.SetActive(true);
        }
        else
        {
            var prefab = Resources.Load<Monster>("Prefabs/Monster/NormalMonster");
            monster = Instantiate(prefab);

            monster.OnReturnToPool += ReturnMonsterToPool;
        }
        return monster;
    }

    private void ReturnMonsterToPool(Monster monster)
    {
        monsterPool.Enqueue(monster);
    }
}
