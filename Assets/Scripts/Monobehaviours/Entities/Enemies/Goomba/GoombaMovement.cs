using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour, IMoveable
{
    public float speed;
    public GameObject leftWaypoint;
    public GameObject rightWaypoint;

    Rigidbody2D rigidBody;

    IMoveable.MoveDirections currentMoveDirection;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        currentMoveDirection = IMoveable.MoveDirections.Left;
    }
    public void Move(IMoveable.MoveDirections moveDirection)
    {
        if(moveDirection == IMoveable.MoveDirections.Any)
        {
            if (currentMoveDirection == IMoveable.MoveDirections.Left)
            {
                rigidBody.velocity = -transform.right * speed;
            }
            else if (currentMoveDirection == IMoveable.MoveDirections.Right)
            {
                rigidBody.velocity = transform.right * speed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == leftWaypoint)
        {
            currentMoveDirection = IMoveable.MoveDirections.Right;
        }
        else if (collision.gameObject == rightWaypoint)
        {
            currentMoveDirection = IMoveable.MoveDirections.Left;
        }
    }
}
