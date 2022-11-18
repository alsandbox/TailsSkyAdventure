using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject lifeUI;
    public int livesCounter = 0;
    
    public void DecreaseLife()
    {
        GameObject currentLifeUI = lifeUI.transform.GetChild(livesCounter).gameObject;
        currentLifeUI.SetActive(false);
        livesCounter++;
    }
}
