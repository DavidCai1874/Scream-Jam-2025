using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    public event EventHandler E_Pressed; //hit E

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


    }

    private void OnDestroy()
    {
        Instance = null;

        playerInputAction.Player.Interact.performed -= Interact_performed; // when the key in Interact "E" is hit, call this function

        playerInputAction.Dispose();
    }


    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) //parameter including infos about the key pressed
    {
        E_Pressed?.Invoke(this, EventArgs.Empty);
        Debug.Log("Interact pressed");
    }


}
