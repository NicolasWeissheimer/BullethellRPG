using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Potion : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float duration;
    public float life;
    public float mana;
    public float stamina;
    public int attack;
    public int faith;
    public int dexterity;
    public int speed;
    public int defense;
    public int vitality;
    public int wisdom;
    public int resitence;
    public int ammount;
    public TextMeshProUGUI text;
    public Item item;
    bool buffed;

    public ToolTip tooltipPopup;

    private void Start()
    {
        gameObject.GetComponent<ItemRarity>().rarity = item.rarity.rarityID;
        tooltipPopup = GameObject.FindObjectOfType<ToolTip>();
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        SetText();
    }

    public void GiveBuff()
    {
        if(buffed == false && ammount > 0)
        {
            PlayerStats.life += life;
            PlayerStats.mana += mana;
            PlayerStats.stamina += stamina;
            PlayerStats.attack += attack;
            PlayerStats.faith += faith;
            PlayerStats.dexterity += dexterity;
            PlayerStats.speed += speed;
            PlayerStats.defense += defense;
            PlayerStats.vitality += vitality;
            PlayerStats.wisdom += wisdom;
            PlayerStats.resistance += resitence;
            ammount--;
            SetText();
            PlayerMovement.SetStats();
            buffed = true;
            StartCoroutine(EffectTime());
        }
    }

    IEnumerator EffectTime()
    {
        yield return new WaitForSeconds(duration);
        RemoveBuff();
    }

    public void RemoveBuff()
    {
        PlayerStats.life -= life;
        PlayerStats.mana -= mana;
        PlayerStats.stamina -= stamina;
        PlayerStats.attack -= attack;
        PlayerStats.faith -= faith;
        PlayerStats.dexterity -= dexterity;
        PlayerStats.speed -= speed;
        PlayerStats.defense -= defense;
        PlayerStats.vitality -= vitality;
        PlayerStats.wisdom -= wisdom;
        PlayerStats.resistance -= resitence;
        PlayerMovement.SetStats();
        buffed = false;
    }

    void SetText()
    {
        text.text = "x" + ammount.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            tooltipPopup.DisplayInfo(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPopup.HideInfo();
    }
}
