using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public static bool isGameOver;
    protected int passedShips = 5;
    protected int lives = 3;

    public UnityEvent DecreaseLifeEvent;

    public void PlayerMissesEnemy() //called from the EnemyController
    {

        if (lives > 0 & passedShips > 0)
        {
            passedShips--;

            if (passedShips == 0)
            {
                lives--;
                DecreaseLifeEvent?.Invoke(); 
                passedShips = 5;
            }
        }
        else if (lives == 0)
        {
            isGameOver = true;
            GameOver();
        }
    }

    protected void EnemyHitsPlayer()
    {
        if (lives > 0)
        {
            lives--;
            DecreaseLifeEvent?.Invoke();
        }

        else if (lives == 0)
        {
            isGameOver = true;
            GameOver();
        }
    }
}
