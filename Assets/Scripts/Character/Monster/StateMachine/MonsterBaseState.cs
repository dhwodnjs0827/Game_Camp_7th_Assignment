public abstract class MonsterBaseState : BaseState
{
    protected readonly Monster monster;
    
    protected MonsterBaseState(MonsterStateMachine stateMachine)
    {
        monster = stateMachine.Monster;
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
