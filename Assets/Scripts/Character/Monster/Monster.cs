using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    [SerializeField] protected MonsterSO data;
    
    private MonsterSpriteController spriteController;
    private MonsterStateMachine stateMachine;

    protected virtual void Awake()
    {
        spriteController = GetComponentInChildren<MonsterSpriteController>();
        stateMachine = new MonsterStateMachine(this);
    }

    protected void Update()
    {
        stateMachine.Execute();
    }

    public void SetMonsterData(MonsterSO data)
    {
        this.data = data;
        spriteController.Init(data.ID);
    }
}
