using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class ResponseButton : MonoBehaviour, IPointerEnterHandler
{
    public static Action<int> highlightButton;
    public TextMeshProUGUI text;
    public Response response;
    public int buttonID;

    public void SetButton(Response r)
    {
        if(r != null)
        {
            text.text = r.responses;
            response = r;
        }

        else
        {
            text.text = "";
        }
    }

    public void SelectResponse()
    {
        response.SelectResponse();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlightButton?.Invoke(buttonID);
    }
}
