using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        animationHash = player.AnimatorController.AnimationData.AttackParameterHash;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Attack 진입");
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Attack 탈출");
    }
}
