using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMiss : MonoBehaviour
{
    public UnityEvent EnemyIsMissing;

    void OnEnable()
    {
        EnemyIsMissing?.Invoke();
    }
}
