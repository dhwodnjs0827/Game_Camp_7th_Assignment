public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }
    
    public PlayerIdleState IdleState { get; }
    public PlayerAttackState AttackState { get; }
    public PlayerHitState HitState { get; }
    public PlayerDieState DieState { get; }

    public PlayerStateMachine(Player player)
    {
        Player = player;
        
        IdleState = new PlayerIdleState(this);
        AttackState = new PlayerAttackState(this);
        HitState = new PlayerHitState(this);
        DieState = new PlayerDieState(this);
        
        ChangeState(IdleState);
    }
}
