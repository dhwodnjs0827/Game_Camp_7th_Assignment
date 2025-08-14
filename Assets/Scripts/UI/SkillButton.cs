using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image coolDownImage;
    [SerializeField] private TextMeshProUGUI stack;
    
    [SerializeField] private SkillSO skill;
}
