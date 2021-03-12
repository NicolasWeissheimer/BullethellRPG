using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Rarity : ScriptableObject
{
    public new string name;
    public Color textColour;
    public int rarityID;

    public string Name { get { return name; } }
    public Color TextColour { get { return textColour; } }
}

