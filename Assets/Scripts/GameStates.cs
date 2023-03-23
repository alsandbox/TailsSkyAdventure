using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/GameStates", fileName = "GameStates")]
public class GameStates : ScriptableObject
{
    public bool IsPaused { get; set; }
    public bool IsGameOver { get; set; }
    public bool EnemyIsDestroyed { get; set; }
    public bool PlayerIsCollided { get; set; }
}
