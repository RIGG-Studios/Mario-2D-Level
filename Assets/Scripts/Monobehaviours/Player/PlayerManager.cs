using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    IMoveable playerMovementLogic;
    IKillable killedLogic;
    IAttackable attackLogic;

    InputActions inputActions;
    GameObject warpPipe;

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.KeyboardAndMouse.Left.performed += ctx => playerMovementLogic.Move(IMoveable.MoveDirections.Left);
   
        inputActions.KeyboardAndMouse.Right.performed += ctx => playerMovementLogic.Move(IMoveable.MoveDirections.Right);

        inputActions.KeyboardAndMouse.Jump.performed += ctx => playerMovementLogic.Move(IMoveable.MoveDirections.Jump);

        inputActions.KeyboardAndMouse.EnterWarpPipe.performed += ctx =>
        {
            if(warpPipe != null)
            {
                warpPipe.GetComponent<WarpPipe>().Teleport(gameObject);
            }
        };

        inputActions.KeyboardAndMouse.Enter.performed += ctx =>
        {
             //Put stuff that happens after you press the enter key here
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (killedLogic.CheckIfDead())
        {
            killedLogic.Die();
        }
        attackLogic.DealDamage(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "WarpPipe")
        {
            warpPipe = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WarpPipe")
        {
            warpPipe = null;
        }
    }

    void Start()
    {
        playerMovementLogic = GetComponent<IMoveable>();
        attackLogic = GetComponent<IAttackable>();
        killedLogic = GetComponent<IKillable>();
    }
}
