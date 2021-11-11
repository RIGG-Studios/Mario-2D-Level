using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovementLogic;
    InputActions inputActions;

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.KeyboardAndMouse.Left.performed += ctx => playerMovementLogic.Move(PlayerMovement.MoveDirections.Left);
   
        inputActions.KeyboardAndMouse.Right.performed += ctx => playerMovementLogic.Move(PlayerMovement.MoveDirections.Right);

        inputActions.KeyboardAndMouse.Jump.performed += ctx => playerMovementLogic.Move(PlayerMovement.MoveDirections.Jump);
    }

    void Start()
    {
        playerMovementLogic = GetComponent<PlayerMovement>();
    }
}
