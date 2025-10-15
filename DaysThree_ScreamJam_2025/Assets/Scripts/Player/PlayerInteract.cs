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
    private bool isCanvasOpen = false;


    public event EventHandler<OnSelectedObjectChangedEventArgs> OnSelectedObjectChanged;
    public class OnSelectedObjectChangedEventArgs : EventArgs
    {
        public BasicInteraction selectedObject;
    }

    private void Awake()
    {
        Instance = this;
        isCanvasOpen = false;
    }

    private void Start()
    {
        gameInput.E_Pressed += GameInput_OnInteractAction;
        DialogueUI.Instance.OnDialogueClose += DialogueUI_OnDialogueClose;
        EndingUI_Day1.Instance.OnEndingClose += EndingUI_OnClose;
    }
    private void OnDestroy()
    {
        gameInput.E_Pressed -= GameInput_OnInteractAction;
        DialogueUI.Instance.OnDialogueClose -= DialogueUI_OnDialogueClose;
        EndingUI_Day1.Instance.OnEndingClose -= EndingUI_OnClose;
    }

    private void DialogueUI_OnDialogueClose(object sender, EventArgs e)
    {
        isCanvasOpen = false;
    }

    private void EndingUI_OnClose(object sender, EventArgs e)
    {
        isCanvasOpen = false;
    }

    ////////////////
    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        //Debug.Log("E key pressed!");
        if (selectedObject != null)
        {
            if (isCanvasOpen == false)
            {

                selectedObject.Interact();
                isCanvasOpen = true;
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

        //Debug.DrawRay(transform.position, lastInteractDir * interactDistance, Color.red);

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
                //RemoveHighlight();
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
