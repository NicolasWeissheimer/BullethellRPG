using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public Slider lifeSlider;
    public Slider staminaSlider;
    public Slider manaSlider;
    public TextMeshProUGUI[] statText;
    public Animator inventory;
    public bool inventoryOpen;
    [Header("Quest")]
    public GameObject questPanel;
    public Transform questContent;
    public GameObject questButton;
    public GameObject questButtons;
    public TextMeshProUGUI acceptText;
    private List<GameObject> activeQuestButons = new List<GameObject>();
    public GameObject lootInventory;
    public GameObject lootInventoryBorder;
    public ItemSlot[] lootSlot;

    private void Start()
    {
        SetStats();
    }

    void Update()
    {
        lifeSlider.maxValue = PlayerStats.maxLife;
        lifeSlider.value = PlayerStats.life;
        staminaSlider.maxValue = PlayerStats.maxStamina;
        staminaSlider.value = PlayerStats.stamina;
        manaSlider.maxValue = PlayerStats.maxMana;
        manaSlider.value = PlayerStats.mana;
        SetStats();

        if (Input.GetKeyDown("e"))
        {
            HideInventory();
        }       
    }

    void ShowQuestPanel(Quest[] quest)
    {
        questPanel.SetActive(true);
        questButtons.SetActive(true);

        for(int i = 0; i < quest.Length; i++)
        {
            if(quest[i].finished == false)
            {
                GameObject button = Instantiate(questButton);
                button.transform.SetParent(questContent);
                button.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                button.GetComponent<OpenQuestButton>().quest = quest[i];
                activeQuestButons.Add(button);
            }
        }
    }

    void HideQuestPanel()
    {
        for (int i = 0; i < activeQuestButons.Count; i++)
        {
            Destroy(activeQuestButons[i].gameObject);
        }

        activeQuestButons.Clear();
        questPanel.SetActive(false);
    }

    void HideQuestButtons()
    {
        questButtons.SetActive(false);
    }

    void ShowQuestButtons()
    {
        questButtons.SetActive(true);
    }

    void HideInventory()
    {
        if(inventoryOpen == true) { inventory.SetTrigger("Close"); inventoryOpen = false; return; }
        if(inventoryOpen == false) { inventory.SetTrigger("Open"); inventoryOpen = true; return; }
    }

    void SetStats()
    {
        statText[0].text = "ATT: " + PlayerStats.attack.ToString();
        statText[1].text = "FTH: " + PlayerStats.faith.ToString();
        statText[2].text = "DEX: " + PlayerStats.dexterity.ToString();
        statText[3].text = "SPD: " + PlayerStats.speed.ToString();
        statText[4].text = "DEF: " + PlayerStats.defense.ToString();
        statText[5].text = "VIT: " + PlayerStats.vitality.ToString();
        statText[6].text = "WIS: " + PlayerStats.wisdom.ToString();
        statText[7].text = "RES: " + PlayerStats.resistance.ToString();
    }

    void OpenLootInventory(GameObject[] items, Color32 color)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            {
                lootSlot[i].slotItem = items[i];
            }
        }
        lootInventoryBorder.GetComponent<Image>().color = color;
        lootInventory.SetActive(true);
    }

    void CloseLootInventory()
    {
        for(int i = 0; i < lootSlot.Length; i++)
        {
            lootSlot[i].slotItem = null;
        }
        lootInventory.SetActive(false);
    }

    private void OnEnable()
    {
        QuestBoard.playerEnter += ShowQuestPanel;
        QuestBoard.playerExit += HideQuestPanel;
        OpenQuestButton.closeButtonList += HideQuestButtons;
        QuestStuff.openQuestButton += ShowQuestButtons;
        LootBag.openBagInventory += OpenLootInventory;
        LootBag.closeBagInventory += CloseLootInventory;
    }

    private void OnDisable()
    {
        QuestBoard.playerEnter -= ShowQuestPanel;
        QuestBoard.playerExit -= HideQuestPanel;      
        OpenQuestButton.closeButtonList -= HideQuestButtons;
        QuestStuff.openQuestButton -= ShowQuestButtons;
        LootBag.openBagInventory -= OpenLootInventory;
        LootBag.closeBagInventory -= CloseLootInventory;
    }
}
