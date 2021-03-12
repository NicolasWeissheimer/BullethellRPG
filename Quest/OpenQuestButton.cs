using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenQuestButton : MonoBehaviour
{
    public Image marker;
    public Sprite[] markers;
    public Quest quest;
    public TextMeshProUGUI questName;
    public static event Action<Quest> openQuestButton;
    public static event Action closeButtonList;

    void Start()
    {
        if (quest != null && quest.ready)
        {
            marker.sprite = markers[1];
        }

        else
        {
            marker.sprite = markers[0];
        }

        if (quest != null) { questName.text = quest.questName; }
    }

    public void OpenQuestStuff()
    {
        openQuestButton?.Invoke(quest);
        CloseButtonList();
    }

    private void OnEnable()
    {
        if (quest != null && quest.finished) { Destroy(gameObject); } 
    }

    void CloseButtonList()
    {
        closeButtonList?.Invoke();
    }
}
