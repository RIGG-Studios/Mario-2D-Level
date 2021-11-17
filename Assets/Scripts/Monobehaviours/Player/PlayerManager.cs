using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    IMoveable playerMovementLogic;
    IKillable killedLogic;
    IAttackable attackLogic;

    InputActions inputActions;

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.KeyboardAndMouse.Left.performed += ctx => playerMovementLogic.Move(IMoveable.MoveDirections.Left);
   
        inputActions.KeyboardAndMouse.Right.performed += ctx => playerMovementLogic.Move(IMoveable.MoveDirections.Right);

        inputActions.KeyboardAndMouse.Jump.performed += ctx => playerMovementLogic.Move(IMoveable.MoveDirections.Jump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (killedLogic.CheckIfDead())
        {
            killedLogic.Die();
        }
        attackLogic.DealDamage(collision);
    }

    void Start()
    {
        playerMovementLogic = GetComponent<IMoveable>();
        attackLogic = GetComponent<IAttackable>();
        killedLogic = GetComponent<IKillable>();
    }
}
