using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : PlayerController
{
    private Animator blink;

    private void Start()
    {
        blink = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        blink.SetTrigger("getsHit");
        EnemyHitsPlayer();
    }
}
