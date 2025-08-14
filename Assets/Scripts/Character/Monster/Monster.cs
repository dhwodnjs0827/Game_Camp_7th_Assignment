using UnityEngine;

public abstract class Monster : MonoBehaviour, IDamageable
{
    [SerializeField] protected MonsterSO data;
    
    private MonsterSpriteController spriteController;
    private MonsterStateMachine stateMachine;
    private BoxCollider2D boxCollider;

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
        stateMachine.ChangeState(stateMachine.AttackState);
        var player = other.gameObject.GetComponent<IDamageable>();
        player.TakeDamage(10f);
    }

    public void SetMonsterData(MonsterSO data)
    {
        this.data = data;
        spriteController.Init(data.ID);
    }

    public void TakeDamage(float damage)
    {
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
