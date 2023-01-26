using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public static bool IsGameOver { get; set; }
    protected int passedShips = 5;
    protected static int lives = 3;

    public UnityEvent DecreaseLifeEvent;

    public AudioSource missedEnemy;

    public UnityEvent GameOverScreen;

    public void PlayerMissesEnemy() //called from the EnemyController
    {
        if (lives > 0 & passedShips > 0 & !IsEnemyColliding.IsCollided)
        {
            missedEnemy.Play();
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
