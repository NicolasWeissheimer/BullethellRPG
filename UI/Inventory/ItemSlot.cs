using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public int slotID;
    public GameObject slotItem;
    public bool lootBag;

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
        }
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        if(pointerEventData.pointerDrag != null)
        {
            pointerEventData.pointerDrag.GetComponent<Transform>().position = GetComponent<Transform>().position;
            pointerEventData.pointerDrag.transform.SetParent(gameObject.transform);
            slotItem = pointerEventData.pointerDrag;

            slotItem.GetComponent<DragDrop>().droppedOnSlot = true;
            slotItem.GetComponent<DragDrop>().defaultPos = transform.position;

            if (Inventory.Instance != null && lootBag == false) { Inventory.Instance.slot[slotID].slotItem = slotItem; }
        }
    }
}
