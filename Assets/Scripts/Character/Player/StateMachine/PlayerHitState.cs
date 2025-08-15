using UnityEngine;

public class PlayerHitState : PlayerBaseState
{
    public PlayerHitState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        animationHash = PlayerAnimationData.Hit;
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
