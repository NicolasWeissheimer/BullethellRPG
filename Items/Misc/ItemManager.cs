using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    public Weapon[] sword;
    public Weapon[] dagger;
    public Weapon[] bow;
    public Weapon[] staff;
    public GameObject[] ability;
    public Armor[] armor;
    public Helm[] helm;
    public Ring[] ring;

    public ItemSlot[] slot;
    

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