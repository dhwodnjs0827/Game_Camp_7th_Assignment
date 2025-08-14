public abstract class PlayerBaseState : BaseState
{
    protected readonly Player player;
    protected int animationHash;
    
    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        player = stateMachine.Player;
    }
    
    public override void Enter()
    {
        StartAnimation();
    }

    public override void Execute()
    {
    }

    public override void Exit()
    {
        StopAnimation();
    }

    private void StartAnimation()
    {
        player.AnimatorController.StartAnimation(animationHash);
    }

    private void StopAnimation()
    {
        player.AnimatorController.StopAnimation(animationHash);
    }
}
