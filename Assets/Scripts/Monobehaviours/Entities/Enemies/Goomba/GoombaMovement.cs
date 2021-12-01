using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaMovement : MonoBehaviour, IMoveable
{
    public float speed;
    public GameObject leftWaypoint;
    public GameObject rightWaypoint;

    Rigidbody2D rigidBody;

    public void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Move(IMoveable.MoveDirections moveDirection)
    {
        if(moveDirection == IMoveable.MoveDirections.Any)
        {
            rigidBody.velocity = transform.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == leftWaypoint)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (collision.gameObject == rightWaypoint)
        {
            transform.rotation = new Quaternion(0, -180, 0, 0);
        }
    }
}
