using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    RectTransform rectTransform;
    GameObject canvasObj;
    Canvas canvas;
    public bool droppedOnSlot;
    public Vector3 defaultPos;
    public GameObject slot;
    void Awake()
    {
        defaultPos = GetComponent<RectTransform>().localPosition;
        canvasObj = GameObject.FindGameObjectWithTag("Finish");
        canvas = canvasObj.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {

    }
    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        droppedOnSlot = false;
        transform.SetParent(canvasObj.transform);
        Color32 color = new Color32(255, 255, 255, 180);
        GetComponent<Image>().color = color;
        GetComponent<Image>().raycastTarget = false;
    }
    public void OnEndDrag(PointerEventData pointerEventData)
    {
        GetComponent<Image>().raycastTarget = true;
        Color32 color = new Color32(255, 255, 255, 255);
        GetComponent<Image>().color = color;
        StartCoroutine(Coroutine());
    }
    public void OnDrag(PointerEventData pointerEventData)
    {
        rectTransform.anchoredPosition += pointerEventData.delta / canvas.scaleFactor;
    }

    public void OnDrop(PointerEventData pointerEventData)
    {

    }

    IEnumerator Coroutine()
    {
        yield return new WaitForEndOfFrame();
        if(droppedOnSlot == false)
        {
            transform.position = defaultPos;
            transform.SetParent(slot.transform);
        }
    }
}
