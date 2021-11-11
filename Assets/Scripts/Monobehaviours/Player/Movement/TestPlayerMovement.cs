using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Just a script to test if I set up movement properly
public class TestPlayerMovement : MonoBehaviour, IPlayerMovable
{
    bool isMovingRight;
    bool isMovingLeft;

    new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    public void Move(IPlayerMovable.MoveDirections moveDirection)
    {
        if(moveDirection == IPlayerMovable.MoveDirections.Left)
        {
            isMovingLeft = !isMovingLeft;
        }
        else if(moveDirection == IPlayerMovable.MoveDirections.Right)
        {
            isMovingRight = !isMovingRight;
        }
        else if(moveDirection == IPlayerMovable.MoveDirections.Jump)
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
