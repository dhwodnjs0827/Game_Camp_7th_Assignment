using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    private PlayerAnimatorController animatorController;

    public PlayerAnimatorController AnimatorController => animatorController;

    private void Awake()
    {
        animatorController = GetComponentInChildren<PlayerAnimatorController>();
        stateMachine = new PlayerStateMachine(this);
    }

    private void Update()
    {
        stateMachine.Execute();
    }
}
