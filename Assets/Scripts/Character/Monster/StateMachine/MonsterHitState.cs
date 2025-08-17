public class MonsterHitState : MonsterBaseState
{
    public MonsterHitState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Execute()
    {
        base.Execute();
        stateMachine.ChangeState(stateMachine.PreviousState);
    }
}
