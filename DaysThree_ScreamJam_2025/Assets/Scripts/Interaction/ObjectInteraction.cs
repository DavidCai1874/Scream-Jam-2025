using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : BasicInteraction
{

    public InteractableObjectSO interactableObjectSO;
    public GameObject oldGeo;
    public GameObject newGeo;

    private Material _originalMat;
    public Material highlightMat;
    private Renderer _renderer;
    private bool _isInteracted = false;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _originalMat = _renderer.material;
        _isInteracted = false;

        if (newGeo != null) newGeo.SetActive(false);
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
        _renderer.material = state ? highlightMat : _originalMat;
    }

    public override void Interact()
    {
        if (_isInteracted) return;
        _isInteracted = true;
        
        GameManager.Instance.AddInteraction();

        if (oldGeo != null) oldGeo.SetActive(false);
        if (newGeo != null) newGeo.SetActive(true);

        DialogueUI.Instance.ShowDialogue(interactableObjectSO);
    }

}
