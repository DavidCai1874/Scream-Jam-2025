using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1_EndingInteraction : BasicInteraction
{
    public EndingSO endingSO;

    void Start()
    {

    }

    public override void Interact()
    {
        Debug.Log("Ending Interacted");
        EndingUI_Day1.Instance.ShowDialogue(endingSO);
    }

}
