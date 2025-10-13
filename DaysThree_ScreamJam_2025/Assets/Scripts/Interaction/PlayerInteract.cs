using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public static PlayerInteract Instance { get; private set; }

    ////////////////
    //SeiralizedFields
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask interactLayerMask;


    ////////////////
    //vairables
    private bool isWalking;
    private Vector3 lastInteractDir;
    private ObjectInteraction selectedObject;
    private bool isCanvasOpen = false;


    ////////////////
    //events
    public event EventHandler<OnSelectedObjectChangedEventArgs> OnSelectedObjectChanged;
    public class OnSelectedObjectChangedEventArgs : EventArgs
    {
        public ObjectInteraction selectedObject;
    }

    private void Awake()
    {
        Instance = this;
        isCanvasOpen = false;
    }

    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
        DialogueUI.Instance.OnDialogueClose += DialogueUI_OnDialogueClose;
    }
    private void OnDestroy()
    {
        gameInput.OnInteractAction -= GameInput_OnInteractAction;
        DialogueUI.Instance.OnDialogueClose -= DialogueUI_OnDialogueClose;
    }

    private void DialogueUI_OnDialogueClose(object sender, EventArgs e)
    {
        isCanvasOpen = false;
        Debug.Log(isCanvasOpen);
    }

    ////////////////
    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        //Debug.Log("E key pressed!");
        if (selectedObject != null)
        {
            if (isCanvasOpen == false)
            {
                Debug.Log("Interacting with " + selectedObject.gameObject.name);
                selectedObject.Interact();
                isCanvasOpen = true;
                Debug.Log(isCanvasOpen);
            }
        }
    }

    private void Update()
    {
        HandleInteractions();
    }



    private void HandleInteractions()
    {

        float interactDistance = 3f;
        
        lastInteractDir = Camera.main.transform.forward;

        // Debug.DrawRay(transform.position, lastInteractDir * interactDistance, Color.red);

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit hit, interactDistance, interactLayerMask))
        {

            // Debug.Log("We hit " + hit.transform.gameObject.name + " " + hit.transform.position);

            if (hit.transform.TryGetComponent(out ObjectInteraction objectBeingTouched))
            {
                if (objectBeingTouched != selectedObject)
                {
                    SetSelectedObject(objectBeingTouched);

                }

            }
            else
            {
                //RemoveHighlight();
                SetSelectedObject(null);
            }

        }
        else
        {
            SetSelectedObject(null);
        }
    }

    private void SetSelectedObject(ObjectInteraction newObject)
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
