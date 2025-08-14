using UnityEngine;
using UnityEngine.U2D.Animation;

public class MonsterSpriteController : MonoBehaviour
{
    private SpriteLibrary spriteLibrary;
    private SpriteResolver spriteResolver;

    private void Awake()
    {
        spriteLibrary = GetComponent<SpriteLibrary>();
        spriteResolver = GetComponent<SpriteResolver>();
    }

    public void Init(string id)
    {
        spriteLibrary.spriteLibraryAsset = Resources.Load<SpriteLibraryAsset>($"SpriteLibrary/{id}");
        spriteResolver.SetCategoryAndLabel("Move", "01");
    }
}
