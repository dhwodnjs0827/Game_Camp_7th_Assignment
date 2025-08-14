using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("몬스터 Attack 진입");
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
