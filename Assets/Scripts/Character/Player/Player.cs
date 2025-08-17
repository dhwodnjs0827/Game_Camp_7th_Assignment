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

    private void OnEnable()
    {
        if (UIManager.Instance.IsUIActive<MainUI>())
        {
            var mainUI = UIManager.Instance.GetUI<MainUI>();
            mainUI.OnClickCreateSkill += StartAttack;
        }
    }

    private void Start()
    {
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void OnDisable()
    {
        if (UIManager.Instance.IsUIActive<MainUI>())
        {
            var mainUI = UIManager.Instance.GetUI<MainUI>();
            mainUI.OnClickCreateSkill -= StartAttack;
        }
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
                stateMachine.ChangeState(stateMachine.DieState);
                return;
            }
            stateMachine.ChangeState(stateMachine.HitState);
        }
    }

    private void StartAttack()
    {
        stateMachine.ChangeState(stateMachine.AttackState);
        if (UIManager.Instance.IsUIActive<MainUI>())
        {
            var mainUI = UIManager.Instance.GetUI<MainUI>();
            mainUI.OnClickCreateSkill -= StartAttack;
        }
    }

    public void Dead()
    {
        Destroy(statController);
        Destroy(skillController);
    }
}