using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Response : ScriptableObject
{
    public string responses;
    public Dialogue dialogue;
    public static Action<Dialogue> buildDialogue;

    public virtual void ResponseEffect()
    {

    }

    public void SelectResponse()
    {
        ResponseEffect();
        buildDialogue?.Invoke(dialogue);
    }
}
