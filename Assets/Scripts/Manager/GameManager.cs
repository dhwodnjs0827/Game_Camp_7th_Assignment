using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private MainUI mainUI;
    public MainUI MainUI => mainUI;
}