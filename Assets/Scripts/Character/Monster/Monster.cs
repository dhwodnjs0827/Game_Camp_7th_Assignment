using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    [SerializeField] protected MonsterSO data;
    protected IDamageable target;
    
    private MonsterSpriteController spriteController;
    private MonsterStateMachine stateMachine;
    private BoxCollider2D boxCollider;

    public MonsterSO Data => data;
    public IDamageable Target => target;
    public BoxCollider2D BoxCollider => boxCollider;

    protected virtual void Awake()
    {
        spriteController = GetComponentInChildren<MonsterSpriteController>();
        boxCollider = GetComponent<BoxCollider2D>();
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
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"몬스터 {damage} 받음");
        Destroy(gameObject);
        // if (statController.CurrentHP > 0f)
        // {
        //     statController.Damaged(damage);
        //     if (statController.CurrentHP <= 0f)
        //     {
        //         Dead();
        //         return;
        //     }
        //     stateMachine.ChangeState(stateMachine.HitState);
        // }
    }
}
