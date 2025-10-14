using System.Collections;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = true;

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            StartCoroutine(WaitCallback());
        }
    }

    private IEnumerator WaitCallback()
    {
        yield return new WaitForSecondsRealtime(2f);
        Loader.LoaderCallback();
    }
}