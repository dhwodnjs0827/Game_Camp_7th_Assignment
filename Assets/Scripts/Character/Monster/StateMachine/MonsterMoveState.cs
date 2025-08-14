using DataDeclaration;
using UnityEngine;

public class MonsterMoveState : MonsterBaseState
{
    public MonsterMoveState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Execute()
    {
        base.Execute();
        Move();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void Move()
    {
        monster.transform.position += new Vector3(0f, MonsterConstants.MoveSpeed * Time.deltaTime, 0f);
    }
}
