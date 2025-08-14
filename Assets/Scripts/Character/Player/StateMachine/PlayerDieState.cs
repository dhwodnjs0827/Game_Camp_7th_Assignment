using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public PlayerDieState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        animationHash = PlayerAnimationData.Die;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Die 진입");
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Die 탈출");
    }
}
