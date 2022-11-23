using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int playerIndex;
    public int lives;
    public int passedShips;
    public UnityEvent livesEvent;
    public bool enemyDestroyed;

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
        passedShips = 5;
    }

    public void EnemyHitsPlayer(int enemyNumber)
    {
        if (enemyNumber == playerIndex & lives != 0 & !enemyDestroyed)
        {
            lives--;
            livesEvent.Invoke();
        }
    }

    public void PlayerMissesEnemy(int enemyNumber)
    {
        if (enemyNumber != playerIndex & lives != 0 & passedShips > 0)
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
