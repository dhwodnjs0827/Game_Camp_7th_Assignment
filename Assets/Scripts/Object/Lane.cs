using UnityEngine;

public class Lane : MonoBehaviour
{
    [SerializeField] private Transform playerArea;

    private void Awake()
    {
        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        Player prefab = Resources.Load<Player>("Prefabs/Player");
        Instantiate(prefab, playerArea.position, Quaternion.identity);
    }
}
