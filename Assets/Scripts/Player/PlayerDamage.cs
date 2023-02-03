using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : MonoBehaviour
{
    private Animator blink;
    private AudioSource playersDamageSound;
    public UnityEvent EnemyHitsPlayer;
    public static bool IsCollided { get; set; }

    private void Start()
    {
        playersDamageSound = GetComponent<AudioSource>();
        blink = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        IsCollided = true;
        blink.SetTrigger("getsHit");
        playersDamageSound.Play();
        EnemyHitsPlayer?.Invoke();

        if (PlayerController.IsGameOver)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        IsCollided = false;
    }
}
