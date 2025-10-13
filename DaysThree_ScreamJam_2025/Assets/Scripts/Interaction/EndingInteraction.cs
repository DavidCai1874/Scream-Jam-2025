using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingInteraction : MonoBehaviour
{
    public EndingSO endingSO;

    void Start()
    {

    }

    public void Interact()
    {
        DialogueUI.Instance.ShowDialogue(interactableObjectSO);
    }

}
