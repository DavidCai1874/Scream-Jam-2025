using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2_EndingInteraction : BasicInteraction
{
    public EndingSO endingSO;

    void Start()
    {

    }

    public override void Interact()
    {
        EndingUI_Day2.Instance.ShowDialogue(endingSO);
    }

}
