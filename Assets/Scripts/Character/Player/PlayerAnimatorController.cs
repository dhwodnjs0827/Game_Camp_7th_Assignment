using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator animator;
    
    public PlayerAnimationData AnimationData { get; private set; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        AnimationData = new PlayerAnimationData();
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
