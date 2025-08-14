public class MonsterStateMachine : StateMachine
{
    public Monster Monster { get; }
    
    public MonsterMoveState MoveState { get; }
    public MonsterAttackState AttackState { get; }
    public MonsterHitState HitState { get; }
    public MonsterDieState DieState { get; }

    public MonsterStateMachine(Monster monster)
    {
        Monster = monster;
        
        MoveState = new MonsterMoveState(this);
        AttackState = new MonsterAttackState(this);
        HitState = new MonsterHitState(this);
        DieState = new MonsterDieState(this);
    }
}
