using System;
using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    [SerializeField] protected MonsterSO data;
    protected IDamageable target;
    
    private MonsterSpriteController spriteController;
    private MonsterStatController statController;
    private MonsterStateMachine stateMachine;
    
    public MonsterStatController StatController => statController;
    public IDamageable Target => target;

    public event Action<Monster> OnReturnToPool;

    protected virtual void Awake()
    {
        spriteController = GetComponentInChildren<MonsterSpriteController>();
        statController = GetComponent<MonsterStatController>();
        stateMachine = new MonsterStateMachine(this);
    }

    protected virtual void Start()
    {
        stateMachine.ChangeState(stateMachine.MoveState);
    }

    protected virtual void Update()
    {
        stateMachine.Execute();
    }

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            stateMachine.ChangeState(stateMachine.AttackState);
            target = other.gameObject.GetComponent<IDamageable>();
        }
    }

    public void SetMonsterData(MonsterSO data)
    {
        this.data = data;
        spriteController.Init(data.ID);
        statController.InitStats(data);
        stateMachine.ChangeState(stateMachine.MoveState);
    }

    public void TakeDamage(float damage)
    {
        if (statController.CurrentHP > 0f)
        {
            statController.Damaged(damage);
            if (statController.CurrentHP <= 0f)
            {
                stateMachine.ChangeState(stateMachine.DieState);
                return;
            }
            stateMachine.ChangeState(stateMachine.HitState);
        }
    }

    public void Dead()
    {
        GameManager.Instance.IncreaseGold(data.DropGold);
        
        OnReturnToPool?.Invoke(this);
        
        gameObject.SetActive(false);
    }
}
