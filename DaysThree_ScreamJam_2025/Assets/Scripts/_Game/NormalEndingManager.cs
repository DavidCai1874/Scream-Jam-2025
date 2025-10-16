using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEndingManager : MonoBehaviour
{
    public float countdownTime = 2f;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSecondsRealtime(countdownTime);
        Loader.LoadNormal(Loader.Scene.Main_Menu_Scene);
    }

}
