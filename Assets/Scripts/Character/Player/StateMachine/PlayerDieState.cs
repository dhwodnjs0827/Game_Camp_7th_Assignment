using UnityEngine;

public class PlayerDieState : PlayerBaseState
{
    public PlayerDieState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        animationHash = PlayerAnimationData.Die;
    }

    public override void Execute()
    {
        if (IsAnimationEnd())
        {
            player.Dead();
        }
    }
    
    private bool IsAnimationEnd()
    {
        AnimatorStateInfo stateInfo = player.AnimatorController.Animator.GetCurrentAnimatorStateInfo(0);
        if (!stateInfo.IsName("Player_Die"))
        {
            return false;
        }
        return stateInfo.normalizedTime >= 1f;
    }
}
