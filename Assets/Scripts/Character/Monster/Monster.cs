using UnityEngine;

public abstract class Monster : MonoBehaviour
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
        Debug.Log("충돌 발생");
        stateMachine.ChangeState(stateMachine.AttackState);
    }

    public void SetMonsterData(MonsterSO data)
    {
        this.data = data;
        spriteController.Init(data.ID);
    }
}
