using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class HelmObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    public Helm helm;
    public ToolTip tooltipPopup;

    void Start()
    {
        gameObject.GetComponent<ItemRarity>().rarity = helm.rarity.rarityID;
        tooltipPopup = GameObject.FindObjectOfType<ToolTip>();
        GetComponent<Image>().sprite = helm.sprite;
        life = helm.life;
        mana = helm.mana;
        stamina = helm.speed;
        attack = helm.attack;
        faith = helm.faith;
        dexterity = helm.dexterity;
        speed = helm.speed;
        defense = helm.defense;
        vitality = helm.vitality;
        wisdom = helm.wisdom;
        resistance = helm.resistance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipPopup.DisplayInfo(helm);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPopup.HideInfo();
    }
}
