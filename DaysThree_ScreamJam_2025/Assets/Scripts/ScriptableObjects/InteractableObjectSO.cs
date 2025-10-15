using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InteractableObjectSO")]
public class InteractableObjectSO : ScriptableObject
{
    public TextAsset dialogueTextFile;
    public Sprite image;
    public AudioClip interactionSound;

    public string GetDialogueText()
    {
        return dialogueTextFile != null ? dialogueTextFile.text : "";
    }
}