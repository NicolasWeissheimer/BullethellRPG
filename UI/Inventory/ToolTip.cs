using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Text;

public class ToolTip : MonoBehaviour
{
    public GameObject popupCanvasObject;
    public RectTransform popupObject;
    public TextMeshProUGUI infoText;
    public Vector3 offset;
    public Image background;
    public float padding;

    private Canvas popupCanvas;

    private void Awake()
    {
        popupCanvas = popupCanvasObject.GetComponent<Canvas>();
    }

    private void Update()
    {
        FollowCursor();
    }

    private void FollowCursor()
    {
        if (!popupCanvasObject.activeSelf) { return; }

        Vector3 newPos = Input.mousePosition + offset;
        newPos.z = 0f;
        float rightEdgeToScreenEdgeDistance = Screen.width - (newPos.x + popupObject.rect.width * popupCanvas.scaleFactor / 2) - padding;
        if (rightEdgeToScreenEdgeDistance < 0)
        {
            newPos.x += rightEdgeToScreenEdgeDistance;
        }
        float leftEdgeToScreenEdgeDistance = 0 - (newPos.x - popupObject.rect.width * popupCanvas.scaleFactor / 2) + padding;
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            newPos.x += leftEdgeToScreenEdgeDistance;
        }
        float topEdgeToScreenEdgeDistance = Screen.height - (newPos.y + popupObject.rect.height * popupCanvas.scaleFactor) - padding;
        if (topEdgeToScreenEdgeDistance < 0)
        {
            newPos.y += topEdgeToScreenEdgeDistance;
        }
        popupObject.transform.position = newPos;
    }

    public void DisplayInfo(Item item)
    {
        StringBuilder builder = new StringBuilder();

        builder.Append("<size=35>").Append(item.ColouredName).Append("</size>").AppendLine();
        builder.Append(item.GetTooltipInfoText());

        infoText.text = builder.ToString();
        background.color = item.color;

        popupCanvasObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(popupObject);
    }

    public void HideInfo()
    {
        popupCanvasObject.SetActive(false);
    }
}
