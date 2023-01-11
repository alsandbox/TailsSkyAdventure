using UnityEngine;

public class PlayerDamage : PlayerController
{
    private Animator blink;
    private AudioSource playersDamageSound;

    private void Start()
    {
        blink = GetComponent<Animator>();
        playersDamageSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        blink.SetTrigger("getsHit");
        playersDamageSound.Play();
        EnemyHitsPlayer();

        if (IsGameOver)
        {
            this.gameObject.SetActive(false);
        }
    }
}
