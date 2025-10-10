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


    ////////////////
    //vairables
    private bool isWalking;
    private Vector3 lastInteractDir;
    private ObjectInteraction selectedObject;


    ////////////////
    //events
    public event EventHandler<OnSelectedObjectChangedEventArgs> OnSelectedObjectChanged;
    public class OnSelectedObjectChangedEventArgs : EventArgs
    {
        public ObjectInteraction selectedObject;
    }

    public event EventHandler OnPickedSomthing;



    private void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }


    ////////////////
    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        //if (!GameManager.Instance.IsGamePlaying()) return;//if game ends or not started, not able to interact

        //Debug.Log("E key pressed!");
        if (selectedObject != null)
        {
            selectedObject.Interact(this);
        }
    }

    private void Update()
    {
        HandleInteractions();
    }



    private void HandleInteractions()
    {

        float interactDistance = 2f;
        
        lastInteractDir = Camera.main.transform.forward;

        Debug.DrawRay(transform.position, lastInteractDir * interactDistance, Color.red);

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit hit, interactDistance))
        {

            Debug.Log("We hit " + hit.transform.gameObject.name + " " + hit.transform.position);

            if (hit.transform.TryGetComponent(out ObjectInteraction objectBeingTouched))
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
