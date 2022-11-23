using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D fire)
    {
        GameManager.Instance.enemyDestroyed = true;
        this.gameObject.SetActive(false);
    }
}
