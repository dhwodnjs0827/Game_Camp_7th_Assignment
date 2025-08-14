using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    [SerializeField] protected MonsterSO data;
    
    private SpriteController spriteController;

    protected virtual void Awake()
    {
        spriteController = GetComponentInChildren<SpriteController>();
        spriteController.Init(data.ID);
    }
}
