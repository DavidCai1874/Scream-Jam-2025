using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;

    public GameObject panel;
    public Image dialogueImage;
    public Text dialogueText;

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    public void ShowDialogue(InteractableObjectSO interactableObjectSO)
    {
        dialogueImage.sprite = interactableObjectSO.image;
        //dialogueText.text = interactableObjectSO.GetDialogueText();
        panel.SetActive(true);
    }

    //public void CloseDialogue()
    //{
    //    panel.SetActive(false);
    //}
}
