using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Player player;
    [SerializeField] Transform playerRespawnPoint;
    
    public Player Player => player;

    protected override void Awake()
    {
        base.Awake();
        RespawnPlayer();
    }

    private void RespawnPlayer()
    {
        Player prefab = Resources.Load<Player>("Prefabs/Player");
        player = Instantiate(prefab, playerRespawnPoint.position, Quaternion.identity);
    }
}