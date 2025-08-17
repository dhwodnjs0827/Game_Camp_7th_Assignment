public abstract class MonsterBaseState : BaseState
{
    protected readonly Monster monster;
    protected readonly MonsterStateMachine stateMachine;
    
    protected MonsterBaseState(MonsterStateMachine stateMachine)
    {
        monster = stateMachine.Monster;
        this.stateMachine = stateMachine;
    }
    
    public override void Enter()
    {
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
    }
}
