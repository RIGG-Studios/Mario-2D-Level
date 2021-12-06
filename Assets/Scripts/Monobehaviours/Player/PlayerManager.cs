using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Interfaces playermovementlogic, killed logic, and attack logic
    IMoveable playerMovementLogic;
    IKillable killedLogic;
    IAttackable attackLogic;

    //Inut actions asset and the current warp pipe
    InputActions inputActions;
    GameObject warpPipe;


    //Enabling/disabling the input actions
    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();


    //On awake
    private void Awake()
    {
        //Create input actions, needed to make input work
        inputActions = new InputActions();

        //When the left keybind is pressed, call move with a movedirection
        inputActions.KeyboardAndMouse.Left.performed += ctx => playerMovementLogic.Move(IMoveable.MoveDirections.Left);

        //When the right keybind is pressed, call move with a movedirection
        inputActions.KeyboardAndMouse.Right.performed += ctx => playerMovementLogic.Move(IMoveable.MoveDirections.Right);

        //When the jump keybind is pressed, call move with a movedirection
        inputActions.KeyboardAndMouse.Jump.performed += ctx => playerMovementLogic.Move(IMoveable.MoveDirections.Jump);

        //When the enter warp pipe keybind is pressed, call teleport with the player if there is a current warp pipe
        inputActions.KeyboardAndMouse.EnterWarpPipe.performed += ctx =>
        {
            if(warpPipe != null)
            {
                warpPipe.GetComponent<WarpPipe>().Teleport(gameObject);
            }
        };
    }

    //On collision enter 2d
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player is dead
        if (killedLogic.CheckIfDead())
        {
            //Die
            killedLogic.Die();
        }
        //Deal damage
        attackLogic.DealDamage(collision);
    }

    //On trigger enter 2d
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player steps on a warp pipe, then set current warp pipe to this pipe
        if (collision.gameObject.tag == "WarpPipe")
        {
            warpPipe = collision.gameObject;
        }
    }

    //On trigger exit 2d
    private void OnTriggerExit2D(Collider2D collision)
    {
        //If the player gets off a warp pipe, then set current warp pipe to null
        if (collision.gameObject.tag == "WarpPipe")
        {
            warpPipe = null;
        }
    }

    //Start
    void Start()
    {
        //Get the attached interfaces, the player must have all 3 attached to work
        playerMovementLogic = GetComponent<IMoveable>();
        attackLogic = GetComponent<IAttackable>();
        killedLogic = GetComponent<IKillable>();
    }
}
