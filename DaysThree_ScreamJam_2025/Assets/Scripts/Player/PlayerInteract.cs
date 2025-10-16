using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public static PlayerInteract Instance { get; private set; }

    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask interactLayerMask;

    private Vector3 lastInteractDir;
    private BasicInteraction selectedObject;


    public event EventHandler<OnSelectedObjectChangedEventArgs> OnSelectedObjectChanged;
    public class OnSelectedObjectChangedEventArgs : EventArgs
    {
        public BasicInteraction selectedObject;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameInput.E_Pressed += GameInput_OnInteractAction;
    }
    private void OnDestroy()
    {
        gameInput.E_Pressed -= GameInput_OnInteractAction;
    }


    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if (selectedObject != null)
        {

            selectedObject.Interact();

        }
    }

    private void Update()
    {
        HandleInteractions();
    }



    private void HandleInteractions()
    {

        float interactDistance = 3.6f;
        
        lastInteractDir = Camera.main.transform.forward;

        Debug.DrawRay(transform.position, lastInteractDir * interactDistance, Color.red);

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit hit, interactDistance, interactLayerMask))
        {

            //Debug.Log("We hit " + hit.transform.gameObject.name + " " + hit.transform.position);

            if (hit.transform.TryGetComponent(out BasicInteraction objectBeingTouched))
            {
                if (objectBeingTouched != selectedObject)
                {
                    SetSelectedObject(objectBeingTouched);

                }

            }
            else
            {
                SetSelectedObject(null);
            }

        }
        else
        {
            SetSelectedObject(null);
        }
    }

    private void SetSelectedObject(BasicInteraction newObject)
    {
        if (selectedObject != newObject) //if the counter selected is not the param counter send in, e.g. null, clear counter, etc
        {
            selectedObject = newObject;

            OnSelectedObjectChanged?.Invoke(this, new OnSelectedObjectChangedEventArgs // send this event with the param of the counter, null/ smthing
            {
                selectedObject = selectedObject
            });
        }
    }


}
