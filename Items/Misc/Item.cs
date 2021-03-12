using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public new string name;
    public int sellPrice;
    public Sprite sprite;
    public Rarity rarity;

    public string Name { get { return name; } }
    public abstract string ColouredName { get; }
    public abstract Color color { get; }
    public int SellPrice { get { return sellPrice; } }

    public abstract string GetTooltipInfoText();
}


