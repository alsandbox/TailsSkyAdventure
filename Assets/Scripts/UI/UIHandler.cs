using System.Collections;
using UnityEditor;
using UnityEngine;
using System.Runtime.InteropServices;

public class UIHandler : MonoBehaviour
{
    protected int sceneID;
    [SerializeField] protected Animator transitionAnimator;
    protected readonly float transitionDelayTime = 0.3f;
    private readonly float exitDelayTime = 0.2f;

    [DllImport("__Internal")]
    private static extern void CloseCurrentWindow();

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
            CloseCurrentWindow();
#else
            Application.Quit();
#endif
    }
}
