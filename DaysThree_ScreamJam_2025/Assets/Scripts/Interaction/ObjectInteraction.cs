using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : BasicInteraction
{

    public InteractableObjectSO interactableObjectSO;
    public GameObject oldGeo;
    public GameObject highlightGeo;
    public GameObject newGeo;

    private bool _isInteracted = false;

    void Start()
    {
        _isInteracted = false;

        highlightGeo.SetActive(false);
        newGeo.SetActive(false);

        PlayerInteract.Instance.OnSelectedObjectChanged += PlayerInteract_OnSelectedObjectChanged;
    }

    private void PlayerInteract_OnSelectedObjectChanged(object sender, PlayerInteract.OnSelectedObjectChangedEventArgs e)
    {
        if (e.selectedObject == this)
        {
            Highlight(true);
        }
        else
        {
            Highlight(false);
        }
    }

    public void Highlight(bool state)
    {
        if (_isInteracted) return;
        oldGeo.SetActive(!state);
        highlightGeo.SetActive(state);
    }

    public override void Interact()
    {
        if (_isInteracted)
        {
            DialogueUI.Instance.returnInteract();
            return;
        }
        Debug.Log(_isInteracted);
        _isInteracted = true;
        
        GameManager.Instance.AddInteraction();

        GameManager.Instance.sfxPlayer.PlayOneShot(interactableObjectSO.interactionSound);

        highlightGeo.SetActive(false);
        oldGeo.SetActive(false);
        newGeo.SetActive(true);

        DialogueUI.Instance.ShowDialogue(interactableObjectSO);


    }

}
