using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaManager : MonoBehaviour
{
    public GameObject leftWaypoint;
    public GameObject rightWaypoint;

    IMoveable movementLogic;
    IKillable deathLogic;
    IAttackable attackLogic;

    IMoveable.MoveDirections currentDirection;

    void Start()
    {
        movementLogic = GetComponent<IMoveable>();
        deathLogic = GetComponent<IKillable>();
        attackLogic = GetComponent<IAttackable>();

        currentDirection = IMoveable.MoveDirections.Left;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == leftWaypoint)
        {
            currentDirection = IMoveable.MoveDirections.Right;
        }
        else if(collision.gameObject == rightWaypoint)
        {
            currentDirection = IMoveable.MoveDirections.Left;
        }

        if (deathLogic.CheckIfDead())
        {
            deathLogic.Die();
        }
        attackLogic.DealDamage(collision);
    }

    void FixedUpdate()
    {
        movementLogic.Move(currentDirection);
    }
}
