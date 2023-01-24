using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonStates : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject highlight;
    private bool firstSelectedNone = true;

    private void Awake()
    {
        highlight = transform.GetChild(1).gameObject;
    }

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

    public void OnSelect(BaseEventData eventData)
    {
        highlight.SetActive(true);
    }

    public void OnDeselect(BaseEventData data)
    {
        highlight.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.SetActive(false);
    }
}
