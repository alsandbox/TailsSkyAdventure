using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public GameObject lifeUI;
    public GameObject flagsUI;

    private int livesCounter = 0;
    private int flagsCounter = 0;

    private AudioSource newLevelSound;
    private AudioSource gameOverAudioSource;
    private AudioSource winAudioSource;

    private Animator gameOverAnimator;
    private Animator winAnimator;

    private float gameOverDelay;
    private float winDelay;

    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public GameObject tails;

    private GameObject buttonsGameOver;
    private GameObject buttonsWin;

    private int sceneID;

    private void Start()
    {
        sceneID = SceneManager.GetActiveScene().buildIndex;

        gameOverAudioSource = GameOverScreen.GetComponent<AudioSource>();
        gameOverDelay = gameOverAudioSource.clip.length;
        gameOverAnimator = GameOverScreen.GetComponent<Animator>();
        buttonsGameOver = GameOverScreen.transform.GetChild(GameOverScreen.transform.childCount - 1).gameObject;

        winAudioSource = WinScreen.GetComponent<AudioSource>();
        winDelay = winAudioSource.clip.length;
        winAnimator = WinScreen.GetComponent<Animator>();
        buttonsWin = WinScreen.transform.GetChild(WinScreen.transform.childCount - 1).gameObject;
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

    public void Win()
    {
        WinScreen.SetActive(true);
        tails.SetActive(false);
        StartCoroutine(MusicDelay(winDelay));
    }

    public void Restart()
    {
        PlayerController.IsGameOver = false;
        SceneManager.LoadScene(sceneID);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #elif (UNITY_WEBGL)
                    Application.OpenURL("about:blank");
        #else
                    Application.Quit();
        #endif
    }

    IEnumerator MusicDelay(float clipLength)
    {
        if (GameOverScreen.activeSelf)
        {
            yield return new WaitForSeconds(clipLength / 2);
            buttonsGameOver.SetActive(true);

            yield return new WaitForSeconds(clipLength / 2);
            gameOverAnimator.enabled = false;
        }

        if (WinScreen.activeSelf)
        {
            yield return new WaitForSeconds(clipLength);
            winAnimator.enabled = false;
            buttonsWin.SetActive(true);
        }
    }
}
