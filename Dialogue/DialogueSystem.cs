using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Dialogue activeDialogue;
    public ResponseButton[] responseButton;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image arrow;
    public Image charSprite;
    public GameObject responseBox;
    public GameObject dialogueBox;
    public GameObject hehe;
    public Animator animator;

    public void SetArrowPos(int id)
    {
        Vector2 pos = new Vector3(arrow.transform.position.x, responseButton[id].gameObject.transform.position.y);
        arrow.GetComponent<RectTransform>().position = pos;
    }

    void BuildResponseBox(Dialogue res)
    {
        if (res.respondable == false
            )
        {
            EndDialogue();
        }
        else
        {
            responseBox.SetActive(true);
            dialogueBox.SetActive(false);
            for (int i = 0; i < 4; i++)
            {
                if(res.responses[i] != null)
                {
                    responseButton[i].SetButton(res.responses[i]);
                }
                else
                {
                    responseButton[i].gameObject.SetActive(false);
                }
            }
        }
    }

    void BuildDialogueBox(Dialogue dia)
    {
        activeDialogue = dia;
        if(dia.dialogue == null)
        {
            EndDialogue();
        }

        else
        {
            responseBox.SetActive(false);
            dialogueBox.SetActive(true);
            nameText.text = dia.charName;
            dialogueText.text = dia.dialogue;
            charSprite.sprite = dia.charSprite;
        }
    }

    public void NextPage()
    {
        if(dialogueText.pageToDisplay < dialogueText.textInfo.pageCount)
        {
            dialogueText.pageToDisplay++;
        }

        else
        {
            animator.enabled = false;
            BuildResponseBox(activeDialogue);
        }
    }

    void EndDialogue()
    {
        animator.enabled = true;
        animator.SetTrigger("End");
    }

    void StartDialogue(Dialogue dialogue)
    {
        animator.SetTrigger("Start");
        BuildDialogueBox(dialogue);
    }

    private void OnEnable()
    {
        Response.buildDialogue += BuildDialogueBox;
        Dialogue.buildResponse += BuildResponseBox;
        NPC.startDialogue += StartDialogue;
        ResponseButton.highlightButton += SetArrowPos;
    }

    private void OnDisable()
    {
        Response.buildDialogue -= BuildDialogueBox;
        Dialogue.buildResponse -= BuildResponseBox;
        NPC.startDialogue -= StartDialogue;
        ResponseButton.highlightButton -= SetArrowPos;
    }
}
