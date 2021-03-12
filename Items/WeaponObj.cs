using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class WeaponObj : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public GameObject bullet;
    [HideInInspector]
    public float shotSpeed;
    [HideInInspector]
    public float shotLifeTime;
    [HideInInspector]
    public int weight;
    [HideInInspector]
    public int intellect;
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


    public Weapon weapon;
    public ToolTip tooltipPopup;

    void Start()
    {
        gameObject.GetComponent<ItemRarity>().rarity = weapon.rarity.rarityID;
        tooltipPopup = GameObject.FindObjectOfType<ToolTip>();
        GetComponent<Image>().sprite = weapon.sprite;
        damage = weapon.damage;
        bullet = weapon.bullet;
        shotSpeed = weapon.shotSpeed;
        shotLifeTime = weapon.shotLifeTime;
        weight = weapon.weight;
        intellect = weapon.intellect;
        life = weapon.life;
        mana = weapon.mana;
        stamina = weapon.speed;
        attack = weapon.attack;
        faith = weapon.faith;
        dexterity = weapon.dexterity;
        speed = weapon.speed;
        defense = weapon.defense;
        vitality = weapon.vitality;
        wisdom = weapon.wisdom;
        resistance = weapon.resistance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (weapon != null)
        {
            tooltipPopup.DisplayInfo(weapon);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPopup.HideInfo();
    }
}
