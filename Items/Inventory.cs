using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public ItemSlot[] slot;
    public WeaponSlot weaponSlot;
    public RingSlot ringSlot;
    public HelmSlot helmSlot;
    public ArmorSlot armorSlot;
    public PotionSlot potionSlot;
    public GameObject[] containers;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
