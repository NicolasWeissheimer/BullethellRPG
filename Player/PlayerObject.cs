using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public static PlayerObject Instance { get; private set; }

    public PlayerStats playerStats;
    public PlayerAttack playerAttack;
    public PlayerMovement playerMovement;
    public PlayerEquipment playerEquipment;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
