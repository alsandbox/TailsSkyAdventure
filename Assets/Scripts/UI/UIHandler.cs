using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    protected int sceneID;
    [SerializeField] protected Animator transitionAnimator;
    protected readonly float transitionDelayTime = 0.3f;
    private readonly float exitDelayTime = 0.2f;

    protected virtual void Update()
    {
        if (Input.GetMouseButton(0) | Input.GetMouseButton(1) | Input.GetMouseButton(2))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    protected void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Exit()
    {
        StartCoroutine(ExitAfterDelay());
    }

    IEnumerator ExitAfterDelay()
    {
        yield return new WaitForSeconds(exitDelayTime);
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #elif (UNITY_WEBGL)
            Application.OpenURL("about:blank");
        #else
            Application.Quit();
        #endif
    }
}
