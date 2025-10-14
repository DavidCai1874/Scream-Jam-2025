using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class EndingUI : MonoBehaviour
{
    public static EndingUI Instance;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameManager gameManager;

    public GameObject panel;
    public TMP_Text dialogueText;

    private bool isOpen = false;

    public event EventHandler OnEndingClose;


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


    public void ShowDialogue(EndingSO endingSO)
    {
        
        panel.SetActive(true);
        if(gameManager.interactedCount >= 1)
        {
            dialogueText.text = endingSO.All_Text();
        }
        else
        {
            dialogueText.text = endingSO.NotEnough_Text();
        }
        isOpen = true;
    }


    private void CloseDialogue()
    {
        panel.SetActive(false);
        OnEndingClose?.Invoke(this, EventArgs.Empty);
        if(gameManager.interactedCount >= 1)
        {
            Loader.Load(Loader.Scene.Day2_Scene);
        }

    }
}
