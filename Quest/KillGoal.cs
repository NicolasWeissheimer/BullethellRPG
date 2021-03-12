using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewKillQuest", menuName = "Quest/KillQuest")]
public class KillGoal : Quest
{
    public int enemyTypeID;

    public override void Init()
    {
        base.Init();
        QuestEnemy.onEnemyDeath += CheckKillType;
        QuestManager.Instance.activeQuest.Add(this);
    }

    void CheckKillType(int id)
    {
        if(id == enemyTypeID && active == true)
        {
            base.currentAmmount++;
            base.CheckCompleted();
        }
    }
}
