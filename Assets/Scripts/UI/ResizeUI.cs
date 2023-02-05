using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeUI : MonoBehaviour
{
    private GameObject parentCanvas;
    private RectTransform parentRectTransform;
    private RectTransform currentRectTransform;

    void Start()
    {
        parentCanvas = transform.parent.gameObject;
        parentRectTransform = parentCanvas.GetComponentInParent<RectTransform>();
        currentRectTransform = GetComponent<RectTransform>();
        FixCanvasSize();
    }

    private void FixCanvasSize()
    {
        if (parentRectTransform.sizeDelta.x < currentRectTransform.sizeDelta.x)
        {
            currentRectTransform.sizeDelta = new Vector2(parentRectTransform.sizeDelta.x, 0);
        }
    }
}
