using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private Player player;
    [SerializeField] Transform playerRespawnPoint;

    private float[] gameSpeedArray;
    private int gameSpeedIndex;
    private float gameSpeed;

    public Player Player => player;
    public float GameSpeed => gameSpeed;

    protected override void Awake()
    {
        base.Awake();
        RespawnPlayer();
        gameSpeedArray = new float[4] { 1f, 2f, 3f, 5f };
        gameSpeedIndex = 0;
        gameSpeed = gameSpeedArray[gameSpeedIndex];
    }

    public void ChangeGameSpeed()
    {
        gameSpeedIndex = (gameSpeedIndex + 1) % gameSpeedArray.Length;
        gameSpeed = gameSpeedArray[gameSpeedIndex];
        Time.timeScale = gameSpeed;
    }

    private void RespawnPlayer()
    {
        Player prefab = Resources.Load<Player>("Prefabs/Player");
        player = Instantiate(prefab, playerRespawnPoint.position, Quaternion.identity);
    }
}