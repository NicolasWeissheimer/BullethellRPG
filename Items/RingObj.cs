using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class RingObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public Ring ring;
    public ToolTip tooltipPopup;

    void Start()
    {
        gameObject.GetComponent<ItemRarity>().rarity = ring.rarity.rarityID;
        tooltipPopup = GameObject.FindObjectOfType<ToolTip>();
        GetComponent<Image>().sprite = ring.sprite;
        life = ring.life;
        mana = ring.mana;
        stamina = ring.speed;
        attack = ring.attack;
        faith = ring.faith;
        dexterity = ring.dexterity;
        speed = ring.speed;
        defense = ring.defense;
        vitality = ring.vitality;
        wisdom = ring.wisdom;
        resistance = ring.resistance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipPopup.DisplayInfo(ring);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPopup.HideInfo();
    }
}

