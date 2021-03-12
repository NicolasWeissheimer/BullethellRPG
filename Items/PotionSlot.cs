using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PotionSlot : MonoBehaviour, IDropHandler
{ 
    public GameObject slotItem;

    void Start()
    {
        if (slotItem != null)
        {
            GameObject item = Instantiate(slotItem);
            item.transform.SetParent(gameObject.transform);
            item.GetComponent<Transform>().position = GetComponent<Transform>().position;
            item.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
            item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag != null && pointerEventData.pointerDrag.CompareTag("Potion"))
        {
            pointerEventData.pointerDrag.GetComponent<Transform>().position = GetComponent<Transform>().position;
            slotItem = pointerEventData.pointerDrag;
            Potion potion = slotItem.GetComponent<Potion>();
            if (Inventory.Instance != null) { Inventory.Instance.potionSlot.slotItem = slotItem; }
       }
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            DrinkPotion();
        }
    }

    void DrinkPotion()
    {
        if(slotItem != null) { slotItem.GetComponent<Potion>().GiveBuff(); }
    }
}
