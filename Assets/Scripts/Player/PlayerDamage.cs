using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : MonoBehaviour
{
    private Animator blink;
    private AudioSource playersDamageSound;
    public UnityEvent EnemyHitsPlayer;
    public GameStates gameStates;

    private void Start()
    {
        playersDamageSound = GetComponent<AudioSource>();
        blink = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        gameStates.PlayerTsCollided = true;
        blink.SetTrigger("getsHit");
        playersDamageSound.Play();
        EnemyHitsPlayer?.Invoke();

        if (gameStates.IsGameOver)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        gameStates.PlayerTsCollided = false;
    }
}
