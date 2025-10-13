using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InteractableObjectSO")]
public class InteractableObjectSO : ScriptableObject
{
    public string title;
    public TextAsset dialogueTextFile;
    public Sprite image;

    public string GetDialogueText()
    {
        return dialogueTextFile != null ? dialogueTextFile.text : "";
    }
}