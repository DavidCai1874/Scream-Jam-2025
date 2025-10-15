using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class DialogueUI : MonoBehaviour
{
    public static DialogueUI Instance;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameManager gameManager;

    public GameObject panel;
    public Image dialogueImage;
    public TMP_Text dialogueText;

    private bool isOpen = false;

    public event EventHandler OnDialogueClose;


    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
        isOpen = false;
    }

    private void Start()
    {
        gameInput.E_Pressed += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (isOpen)
        {
            CloseDialogue();
            isOpen = false;
        }
    }

    private void OnDestroy()
    {
        gameInput.E_Pressed -= GameInput_OnInteractAction;
    }


    public void ShowDialogue(InteractableObjectSO interactableObjectSO)
    {
        dialogueImage.sprite = interactableObjectSO.image;
        dialogueText.text = interactableObjectSO.GetDialogueText();
        panel.SetActive(true);
        isOpen = true;
    }


    public void ShowStaircase()
    {
        dialogueImage.sprite = null;



        panel.SetActive(true);
        isOpen = true;
    }

    public void returnInteract()
    {
        OnDialogueClose?.Invoke(this, EventArgs.Empty);
    }

    private void CloseDialogue()
    {
        Debug.Log("Dialogue Closed");
        panel.SetActive(false);
        OnDialogueClose?.Invoke(this, EventArgs.Empty);
    }

    
}
