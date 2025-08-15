using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
    private ISkill skill;
    
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        animationHash = PlayerAnimationData.Attack;
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
