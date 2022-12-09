using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyEnemy : MonoBehaviour
{
    private int enemiesNextLevel = 15;
    private static int enemiesCounter = 0;

    public UnityEvent enableTheFlag;

    private void OnTriggerEnter2D(Collider2D fire)
    {
        GameManager.Instance.enemyDestroyed = true;
        this.gameObject.SetActive(false);
        enemiesCounter++;

        if (enemiesCounter % enemiesNextLevel == 0)
        {
            enableTheFlag.Invoke();
        }
    }
}
