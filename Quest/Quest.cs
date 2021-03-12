using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : ScriptableObject
{
    public string questName;
    public string description;
    public int requiredAmmount;
    public int currentAmmount;
    public bool active;
    public bool ready;
    public bool finished;
    public Item[] reward;
    public int goldReward;

    public virtual void Init()
    {

    }

    public void CheckCompleted()
    {
        if(currentAmmount >= requiredAmmount)
        {
            ready = true;
        }

    }

    public void FinishQuest()
    {
        finished = true;
        QuestManager.Instance.completedQuest.Add(this);
        QuestManager.Instance.activeQuest.Remove(this);
    }
}
