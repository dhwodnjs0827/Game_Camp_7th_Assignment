using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    [SerializeField] protected MonsterSO data;
    
    private MonsterSpriteController spriteController;

    protected virtual void Awake()
    {
        spriteController = GetComponentInChildren<MonsterSpriteController>();
        spriteController.Init(data.ID);
    }
}
