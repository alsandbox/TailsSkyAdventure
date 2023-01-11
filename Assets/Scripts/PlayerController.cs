using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    protected int passedShips = 5;
    protected int lives = 3;
    public static bool IsGameOver { get; set; }

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

        if (lives == 0)
        {
            IsGameOver = true;
            GameOverScreen.Invoke();
        }
    }

    protected void EnemyHitsPlayer()
    {
        if (lives > 0)
        {
            lives--;
            DecreaseLifeEvent?.Invoke();
        }

        if (lives == 0)
        {
            IsGameOver = true;
            GameOverScreen.Invoke();
        }
    }
}
