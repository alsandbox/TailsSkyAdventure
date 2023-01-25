using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemyColliding : MonoBehaviour
{
    public static bool IsCollided { get; set; }

    private void OnTriggerEnter2D(Collider2D player)
    {
        IsCollided = true;
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        IsCollided = false;
    }
}
