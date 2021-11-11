using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IPlayerMovable))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    IPlayerMovable playerMovementLogic;
    InputActions inputActions;

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.KeyboardAndMouse.Left.performed += ctx => playerMovementLogic.Move(IPlayerMovable.MoveDirections.Left);
   
        inputActions.KeyboardAndMouse.Right.performed += ctx => playerMovementLogic.Move(IPlayerMovable.MoveDirections.Right);

        inputActions.KeyboardAndMouse.Jump.performed += ctx => playerMovementLogic.Move(IPlayerMovable.MoveDirections.Jump);
    }

    void Start()
    {
        playerMovementLogic = GetComponent<IPlayerMovable>();
    }
}
