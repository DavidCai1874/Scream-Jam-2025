using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingInteraction : BasicInteraction
{
    public EndingSO endingSO;

    void Start()
    {

    }

    public override void Interact()
    {
        Debug.Log("Ending Interacted");
        EndingUI.Instance.ShowDialogue(endingSO);
    }

}
