using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ArmorSlot : MonoBehaviour, IDropHandler
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

            item.GetComponent<DragDrop>().droppedOnSlot = true;
            item.GetComponent<DragDrop>().defaultPos = transform.position;
            item.GetComponent<DragDrop>().slot = gameObject;

            if (Inventory.Instance != null) { Inventory.Instance.armorSlot.slotItem = slotItem; }
            Armor armor = slotItem.GetComponent<ArmorObj>().armor;
            PlayerEquipment.EquipArmor(armor);
        }
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag != null && pointerEventData.pointerDrag.CompareTag("Armor"))
        {
            pointerEventData.pointerDrag.GetComponent<Transform>().position = GetComponent<Transform>().position;
            slotItem = pointerEventData.pointerDrag;

            slotItem.GetComponent<DragDrop>().droppedOnSlot = true;
            slotItem.GetComponent<DragDrop>().defaultPos = transform.position;

            if (Inventory.Instance != null) { Inventory.Instance.armorSlot.slotItem = slotItem; }
            Armor armor = slotItem.GetComponent<ArmorObj>().armor;
            PlayerEquipment.EquipArmor(armor);
        }
    }
}
