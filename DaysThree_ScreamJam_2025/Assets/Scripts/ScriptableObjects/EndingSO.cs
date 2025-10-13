using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EndingSO")]
public class EndingSO : ScriptableObject
{

    public TextAsset Day1_NotEnough;
    public TextAsset Day1_Enough;
    public TextAsset Day1_All;
    public TextAsset Day2_NotEnough;
    public TextAsset Day2_Enough;
    public TextAsset Day2_All;

    public string Day1_NotEnough_Text()
    {
        return Day1_NotEnough != null ? Day1_NotEnough.text : "";
    }

    public string Day1_Enough_Text()
    {
        return Day1_Enough != null ? Day1_Enough.text : "";
    }

    public string Day1_All_Text()
    {
        return Day1_All != null ? Day1_All.text : "";
    }

    public string Day2_NotEnough_Text()
    {
        return Day2_NotEnough != null ? Day2_NotEnough.text : "";
    }

    public string Day2_Enough_Text()
    {
        return Day2_Enough != null ? Day2_Enough.text : "";
    }

    public string Day2_All_Text()
    {
        return Day2_All != null ? Day2_All.text : "";
    }
}

