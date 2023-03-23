using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : UIHandler
{
    public GameObject lifeUI;
    public GameObject flagsUI;

    private int livesCounter;
    private int flagsCounter;

    private AudioSource newLevelSound;
    private AudioSource gameOverAudioSource;
    private AudioSource startAudioSource;

    private Animator gameOverAnimator;
    private Animator winAnimator;

    private float gameOverDelay;
    private float winDelay = 5f;

    public GameObject PauseScreen;
    public GameObject GameOverScreen;
    public GameObject WinScreen;

    public GameObject tails;
    public GameObject fire;

    private GameObject buttonsGameOver;
    private GameObject buttonsWin;

    public GameStates gameStates;

    private void Awake()
    {
        HideCursor();
    }

    private void Start()
    {
        TransitionUI();
        sceneID = SceneManager.GetActiveScene().buildIndex;

        PlayStartSound();

        gameOverAudioSource = GameOverScreen.GetComponent<AudioSource>();
        gameOverDelay = gameOverAudioSource.clip.length;
        gameOverAnimator = GameOverScreen.GetComponent<Animator>();
        buttonsGameOver = GameOverScreen.transform.GetChild(GameOverScreen.transform.childCount - 1).gameObject;

        winAnimator = WinScreen.GetComponent<Animator>();
        buttonsWin = WinScreen.transform.GetChild(WinScreen.transform.childCount - 1).gameObject;
    }

    private void PlayStartSound()
    {
        startAudioSource = GetComponent<AudioSource>();
        startAudioSource.Play();
    }

    private void TransitionUI()
    {
        transitionAnimator.SetTrigger("End");
        StartCoroutine(TransitionDelay());
    }

    IEnumerator TransitionDelay()
    {
        yield return new WaitForSeconds(transitionDelayTime);
        transitionAnimator.gameObject.SetActive(false);
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Escape) & !gameStates.IsGameOver)
        {
            if (!gameStates.IsPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
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

    private void PauseGame()
    {
        gameStates.IsPaused = true;
        PauseScreen.SetActive(true);
        ShowCursor();
    }

    public void ResumeGame()
    {
        gameStates.IsPaused = false;
        PauseScreen.SetActive(false);
        HideCursor();
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        tails.SetActive(false);
        fire.SetActive(false);
        ShowCursor();
        StartCoroutine(MusicDelay(gameOverDelay));
    }

    public void Win()
    {
        WinScreen.SetActive(true);
        tails.SetActive(false);
        fire.SetActive(false);
        ShowCursor();
        StartCoroutine(MusicDelay(winDelay));
    }

    public void RestartGame()
    {
        gameStates.IsGameOver = false;

        if (gameStates.IsPaused == true)
        {
            gameStates.IsPaused = false;
        }

        SceneManager.LoadScene(sceneID);
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
