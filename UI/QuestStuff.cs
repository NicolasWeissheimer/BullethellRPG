using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class QuestStuff : MonoBehaviour
{
    public GameObject panel;
    public bool isReady;
    public TextMeshProUGUI questName;
    public TextMeshProUGUI questDescription;
    public Transform rewardPanel;
    public Item[] rewards;
    public GameObject rewardObject;
    GameObject[] item = new GameObject[8];
    public int goldReward;
    public static event Action openQuestButton;
    public Quest questm;

    void OpenQuestStuff(Quest quest)
    {
        questm = quest;
        panel.SetActive(true);
        isReady = quest.ready;
        questName.text = quest.questName;
        questDescription.text = quest.description;
        goldReward = quest.goldReward;
        rewards = quest.reward;

        if(rewards != null)
        {
            for(int i = 0; i < rewards.Length; i++)
            {
                item[i] = Instantiate(rewardObject);
                item[i].transform.SetParent(rewardPanel);
                item[i].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                item[i].GetComponent<RewardButton>().item = rewards[i];
                item[i].GetComponent<RewardButton>().SetSprite();
            }

        }
    }

    public void CloseQuestStuff()
    {
        panel.SetActive(false);
        for (int i = 0; i < rewards.Length; i++)
        {
            Destroy(item[i]);
        }

        openQuestButton?.Invoke();
    }

    public void AcceptQuest()
    {
        if(questm.active == false)
        {
            questm.active = true;
            questm.Init();
            CloseQuestStuff();
        }

        else if(questm.finished == false && questm.ready == true)
        {
            CloseQuestStuff();
            questm.FinishQuest();
        }
    }

    private void OnEnable()
    {
        QuestBoard.playerExit += CloseQuestStuff;
        OpenQuestButton.openQuestButton += OpenQuestStuff;
    }

    private void OnDisable()
    {
        QuestBoard.playerExit -= CloseQuestStuff;
        OpenQuestButton.openQuestButton -= OpenQuestStuff;
    }
}
