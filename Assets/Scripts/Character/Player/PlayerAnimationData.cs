using UnityEngine;

public static class PlayerAnimationData
{
    public static readonly int Idle = Animator.StringToHash("Idle");
    public static readonly int Attack = Animator.StringToHash("Attack");
    public static readonly int Hit = Animator.StringToHash("Hit");
    public static readonly int Die = Animator.StringToHash("Die");
}
