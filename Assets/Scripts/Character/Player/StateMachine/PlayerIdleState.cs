public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        animationHash = PlayerAnimationData.Idle;
    }
}
