using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour, IMoveable
{
    public float speed;

    Rigidbody2D rigidBody;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Move(IMoveable.MoveDirections moveDirection)
    {
        if(moveDirection == IMoveable.MoveDirections.Left)
        {
            rigidBody.velocity = -transform.right * speed;
        }
        else if(moveDirection == IMoveable.MoveDirections.Right)
        {
            rigidBody.velocity = transform.right * speed;
        }
    }
}
