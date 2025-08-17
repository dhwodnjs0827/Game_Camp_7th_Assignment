using System.Collections;
using DataDeclaration;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageText;

    public void Init(float damage)
    {
        StartCoroutine(DisplayDamageText(damage));
    }

    private IEnumerator DisplayDamageText(float damage)
    {
        damageText.text = damage.ToString("N0");
        
        float duration = 0.5f;
        float elapsed = 0f;
        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + Vector2.up * 2;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            
            Color color = damageText.color;
            color.a = Mathf.Lerp(1f, 0f, elapsed / duration);
            damageText.color = color;
            
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
