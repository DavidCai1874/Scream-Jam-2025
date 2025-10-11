using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction; //hit E
    public event EventHandler OnPauseAction; // hit pause

    public enum Binding
    {
        Interact,
    }

    PlayerInputAction playerInputAction;

    private void Awake()
    {
        Instance = this;
        playerInputAction = new PlayerInputAction();//instance the class in order to get access to the inside functions

        playerInputAction.Player.Enable();

        //bindings
        playerInputAction.Player.Interact.performed += Interact_performed; // when the key in Interact "E" is hit, call this function
        playerInputAction.Player.Pause.performed += Pause_performed;


    }

    private void OnDestroy()
    {
        Instance = null;

        playerInputAction.Player.Interact.performed -= Interact_performed; // when the key in Interact "E" is hit, call this function
        playerInputAction.Player.Pause.performed -= Pause_performed;

        playerInputAction.Dispose();
    }


    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty); // send to game manager, toggle the pause
        Debug.Log("Pause pressed");
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) //parameter including infos about the key pressed
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
        Debug.Log("Interact pressed");
    }


}
