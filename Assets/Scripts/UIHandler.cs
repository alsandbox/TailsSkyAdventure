using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject lifeUI;
    public GameObject flagsUI;

    private int livesCounter = 0;
    private int flagsCounter = 0;

    private AudioSource newLevelSound;
    private AudioSource gameOverAudioSource;

    private Animator gameOverAnimator;

    private float gameOverDelay;

    public GameObject GameOverScreen;

    private void Start()
    {
        gameOverAudioSource = GameOverScreen.GetComponent<AudioSource>();
        gameOverDelay = gameOverAudioSource.clip.length;
        gameOverAnimator = GameOverScreen.GetComponent<Animator>();
    }

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
        newLevelSound = flagsUI.GetComponent<AudioSource>();
        newLevelSound.Play();
        flagsCounter++;
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        StartCoroutine(MusicDelay(gameOverDelay));
    }

    IEnumerator MusicDelay(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        gameOverAnimator.enabled = false;
    }
}
