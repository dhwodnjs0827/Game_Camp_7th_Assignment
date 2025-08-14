using UnityEngine;

public class PlayerAnimationData
{
    private readonly string idleParameterName = "Idle";
    private readonly string attackParameterName = "Attack";
    private readonly string hitParameterName = "Hit";
    private readonly string dieParameterName = "Die";
    
    public int IdleParameterHash { get; private set; }
    public int HitParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int DieParameterHash { get; private set; }

    public PlayerAnimationData()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        HitParameterHash = Animator.StringToHash(hitParameterName);
        DieParameterHash = Animator.StringToHash(dieParameterName);
    }
}
