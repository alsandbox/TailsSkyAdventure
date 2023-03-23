using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuUI : UIHandler
{
    [SerializeField] private GameObject transitionImage;

    void Start()
    {
        sceneID = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void StartGame()
    {
        transitionImage.SetActive(true);
        transitionAnimator.SetTrigger("Start");
        StartCoroutine(StartDelay());

    }

    IEnumerator StartDelay()
    {
        transitionAnimator.gameObject.SetActive(true);
        yield return new WaitForSeconds(transitionDelayTime);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
