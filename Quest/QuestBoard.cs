using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoard : MonoBehaviour
{
    public static event Action<Quest[]> playerEnter;
    public static event Action playerExit;
    public Quest[] quests;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerEnter?.Invoke(quests);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerExit?.Invoke();
        }
    }
}
