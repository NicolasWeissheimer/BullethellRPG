using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour
{
    public GameObject[] items = new GameObject[8];
    public float[] dropChances;
    [HideInInspector]
    public int rarity;
    [HideInInspector]
    public bool droppedAnything;

    public void Drop()
    {
        droppedAnything = false;

        GameObject[] droppedItems = new GameObject[items.Length];

        for(int i = 0; i < items.Length; i++)
        {
            int rng = Random.Range(0, 100);
            if(rng <= dropChances[i])
            {
                droppedItems[i] = items[i];
            }
        }

        for(int i = 0; i < droppedItems.Length; i++)
        {
            if(droppedItems[i] != null)
            {
                droppedAnything = true;

                if(droppedItems[i].GetComponent<ItemRarity>().rarity > rarity)
                {
                    rarity = droppedItems[i].GetComponent<ItemRarity>().rarity;
                }
            }
        }

        if(droppedAnything == true)
        {
            GameObject bag = Instantiate(Inventory.Instance.containers[rarity], transform.position, transform.rotation);
            bag.GetComponent<LootBag>().SetItems(droppedItems);
        }

    }

}
