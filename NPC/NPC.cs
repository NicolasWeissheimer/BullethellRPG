using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;
    public static Action<Dialogue> startDialogue;
    void Update()
    {
        if(Input.GetKeyDown("i"))
        {
            startDialogue?.Invoke(dialogue);
        }
    }
}
