public class PlayerAttackState : PlayerBaseState
{
    private ISkill skill;
    
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        animationHash = PlayerAnimationData.Attack;
    }
}
