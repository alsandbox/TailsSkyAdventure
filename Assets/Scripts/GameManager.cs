using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int enemyIndex;
    private int fireIndex;
    public int playerIndex;
    public int lives;
    private int passedShips = 5;
    public UnityEvent livesEvent;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        lives = 3;
        playerIndex = 0;
        enemyIndex = 0;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void EnemyHitsPlayer()
    {
        if (enemyIndex == playerIndex & lives != 0)
        {
            lives--;
            livesEvent.Invoke();
        }
        else
        {

        }
    }

    public void PlayerMissesEnemy()
    {
        if (enemyIndex != playerIndex & lives != 0)
        {
            passedShips--;

            if (passedShips == 0)
            {
                lives--;
                livesEvent.Invoke();
            }
        }
    }
}
