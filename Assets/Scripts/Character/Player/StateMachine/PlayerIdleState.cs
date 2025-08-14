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
        Debug.Log("Idle 진입");
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Idle 탈출");
    }
}
