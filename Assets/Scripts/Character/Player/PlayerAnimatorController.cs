using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator => animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAnimation(int animationHash)
    {
        animator.SetBool(animationHash, true);
    }

    public void StopAnimation(int animationHash)
    {
        animator.SetBool(animationHash, false);
    }
}
