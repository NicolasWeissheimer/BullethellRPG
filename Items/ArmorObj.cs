using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class ArmorObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector]
    public float life;
    [HideInInspector]
    public float mana;
    [HideInInspector]
    public float stamina;
    [HideInInspector]
    public int attack;
    [HideInInspector]
    public int dexterity;
    [HideInInspector]
    public int faith;
    [HideInInspector]
    public int speed;
    [HideInInspector]
    public int defense;
    [HideInInspector]
    public int vitality;
    [HideInInspector]
    public int wisdom;
    [HideInInspector]
    public int resistance;

    public Armor armor;
    public ToolTip tooltipPopup;

    void Start()
    {
        gameObject.GetComponent<ItemRarity>().rarity = armor.rarity.rarityID;
        tooltipPopup = GameObject.FindObjectOfType<ToolTip>();
        GetComponent<Image>().sprite = armor.sprite;
        life = armor.life;
        mana = armor.mana;
        stamina = armor.speed;
        attack = armor.attack;
        faith = armor.faith;
        dexterity = armor.dexterity;
        speed = armor.speed;
        defense = armor.defense;
        vitality = armor.vitality;
        wisdom = armor.wisdom;
        resistance = armor.resistance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipPopup.DisplayInfo(armor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPopup.HideInfo();
    }
}
