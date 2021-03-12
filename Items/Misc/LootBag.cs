using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject[] items;
    public Color32 rarityColor;
    public static Action<GameObject[], Color32> openBagInventory;
    public static Action closeBagInventory;

    public void SetItems(GameObject[] BagItems)
    {
        items = BagItems;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            openBagInventory?.Invoke(items, rarityColor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            closeBagInventory?.Invoke();
        }
    }
}
