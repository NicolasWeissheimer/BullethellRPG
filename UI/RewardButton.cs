using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RewardButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ToolTip tooltipPopup;
    public Image itemImage;
    public Item item;

    private void Start()
    {
        tooltipPopup = GameObject.FindObjectOfType<ToolTip>();
    }

    public void SetSprite()
    {
        itemImage.sprite = item.sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            tooltipPopup.DisplayInfo(item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipPopup.HideInfo();
    }
}
