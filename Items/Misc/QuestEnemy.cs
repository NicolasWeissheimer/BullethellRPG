using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestEnemy : MonoBehaviour
{
    public static event Action<int> onEnemyDeath;
    public int enemyID;

    private void OnDisable()
    {
        if(onEnemyDeath != null)
        {
            onEnemyDeath(enemyID);
        }
    }
}
