using DataDeclaration;
using UnityEngine;

public class MonsterAttackState : MonsterBaseState
{
    private float damage;
    private float attackCoolDownTimer;

    public MonsterAttackState(MonsterStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        damage = monster.StatController.Attack;
        attackCoolDownTimer = MonsterConstant.ATTACK_SPEED;
    }

    public override void Execute()
    {
        base.Execute();
        attackCoolDownTimer += Time.deltaTime;
        if (attackCoolDownTimer >= MonsterConstant.ATTACK_SPEED)
        {
            Attack();
        }
    }

    private void Attack()
    {
        monster.Target.TakeDamage(damage);
        attackCoolDownTimer = 0f;
    }
}