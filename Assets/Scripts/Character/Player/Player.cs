using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    private PlayerStateMachine stateMachine;
    private PlayerAnimatorController animatorController;
    private PlayerStatController statController;
    private PlayerSkillController skillController;
    
    public PlayerAnimatorController AnimatorController => animatorController;

    private void Awake()
    {
        animatorController = GetComponentInChildren<PlayerAnimatorController>();
        statController = GetComponent<PlayerStatController>();
        skillController = GetComponent<PlayerSkillController>();
        stateMachine = new PlayerStateMachine(this);
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        stateMachine.Execute();
    }

    public void TakeDamage(float damage)
    {
        if (statController.CurrentHP > 0f)
        {
            statController.Damaged(damage);
            if (statController.CurrentHP <= 0f)
            {
                Dead();
                return;
            }
            stateMachine.ChangeState(stateMachine.HitState);
        }
    }

    private void Dead()
    {
        stateMachine.ChangeState(stateMachine.DieState);
    }
}
