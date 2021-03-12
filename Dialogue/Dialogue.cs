using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string dialogue;
    public string charName;
    public Sprite charSprite;
    public bool reepatable;
    public bool respondable;
    public Response[] responses = new Response[4];
    public static Action<Dialogue> buildResponse;

    public void SkipDialogue()
    {
        buildResponse?.Invoke(this);
    }
}
