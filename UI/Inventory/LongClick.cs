using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool pointerDown;
    private float PointerDownTimer;
    public float RequiredTime;
    public UnityEvent onLongClick;

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    void Update()
    {
        if (pointerDown)
        {
            PointerDownTimer += Time.deltaTime;
            if (PointerDownTimer >= RequiredTime)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();

                Reset();
            }
        }
    }

    private void Reset()
    {
        pointerDown = false;
        PointerDownTimer = 0;
    }
}
