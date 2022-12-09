using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : MonoBehaviour
{
    private Animator blink;
    private void Start()
    {
        blink = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        blink.SetTrigger("getsHit");
        GameManager.Instance.EnemyHitsPlayer();
    }
}
