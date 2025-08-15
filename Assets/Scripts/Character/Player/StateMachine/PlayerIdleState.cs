using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        animationHash = PlayerAnimationData.Idle;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
        base.Exit();
    }
}
