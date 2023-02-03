using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public static bool IsGameOver { get; set; }
    private int passedShips = 5;
    private int lives = 3;

    [SerializeField] private AudioSource missedEnemy;

    [SerializeField] private UnityEvent DecreaseLifeEvent;
    [SerializeField] private UnityEvent GameOverEvent;

    public void PlayerMissesEnemy() 
    {
        if (lives > 0 & passedShips > 0 & !PlayerDamage.IsCollided)
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
            GameOverEvent?.Invoke();
        }
    }

    public void EnemyHitsPlayer()
    {
        if (lives > 0)
        {
            lives--;
            DecreaseLifeEvent?.Invoke();
        }

        if (lives == 0)
        {
            IsGameOver = true;
            GameOverEvent?.Invoke();
        }
    }
}
