using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EndingSO")]
public class EndingSO : ScriptableObject
{
    public TextAsset All;
    public TextAsset Enough;
    public TextAsset NotEnough;

    public string All_Text()
    {
        return All != null ? All.text : "";
    }

    public string Enough_Text()
    {
        return Enough != null ? Enough.text : "";
    }

    public string NotEnough_Text()
    {
        return NotEnough != null ? NotEnough.text : "";
    }

}

