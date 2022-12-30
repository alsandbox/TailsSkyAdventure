using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject lifeUI;
    public GameObject flagsUI;
    private int livesCounter = 0;
    private int flagsCounter = 0;

    public void DecreaseLife()
    {
        GameObject currentLifeUI = lifeUI.transform.GetChild(livesCounter).gameObject;
        currentLifeUI.SetActive(false);
        livesCounter++;
    }

    public void ToNewLevel()
    {
        GameObject currentFlagUI = flagsUI.transform.GetChild(flagsCounter).gameObject;
        currentFlagUI.SetActive(true);
        flagsCounter++;
    }
}
