using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Just a script to test if I set up movement properly
public class TestPlayerMovement : MonoBehaviour, PlayerMovement
{
    bool isMovingRight;
    bool isMovingLeft;

    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    public void Move(PlayerMovement.MoveDirections moveDirection)
    {
        if(moveDirection == PlayerMovement.MoveDirections.Left)
        {
            isMovingLeft = !isMovingLeft;
        }
        else if(moveDirection == PlayerMovement.MoveDirections.Right)
        {
            isMovingRight = !isMovingRight;
        }
        else if(moveDirection == PlayerMovement.MoveDirections.Jump)
        {
            Debug.Log("Jumped");
        }
    }

    void Update()
    {
        if (isMovingLeft)
        {
            Debug.Log("Moving left");
        }
        if (isMovingRight)
        {
            Debug.Log("Moving right");
        }
    }
}
