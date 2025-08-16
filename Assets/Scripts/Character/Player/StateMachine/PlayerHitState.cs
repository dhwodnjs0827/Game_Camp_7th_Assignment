using UnityEngine;

public class PlayerHitState : PlayerBaseState
{
    public PlayerHitState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        animationHash = PlayerAnimationData.Hit;
    }

    public override void Execute()
    {
        if (IsAnimationEnd())
        {
            stateMachine.ChangeState(stateMachine.PreviousState);
        }
    }
    
    private bool IsAnimationEnd()
    {
        AnimatorStateInfo stateInfo = player.AnimatorController.Animator.GetCurrentAnimatorStateInfo(0);
        if (!stateInfo.IsName("Player_Hit"))
        {
            return false;
        }
        return stateInfo.normalizedTime >= 1f;
    }
}
