using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonStates : MonoBehaviour
{
    private bool firstSelectedNone = true;

    private void Update()
    {
        SetSelectedButton();
    }

    private void SetSelectedButton()
    {
        if ((Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) & firstSelectedNone)
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
            firstSelectedNone = false;
        }

        if (EventSystem.current.currentSelectedGameObject == null & (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }
}
