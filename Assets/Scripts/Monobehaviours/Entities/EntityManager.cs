using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    IMoveable movementLogic;
    IKillable deathLogic;
    IAttackable attackLogic;

    void Start()
    {
        if(GetComponent<IKillable>() != null)
        {
            deathLogic = GetComponent<IKillable>();
        }

        if(GetComponent<IAttackable>() != null)
        {
            attackLogic = GetComponent<IAttackable>();
        }

        if(GetComponent<IMoveable>() != null)
        {
            movementLogic = GetComponent<IMoveable>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (deathLogic != null && deathLogic.CheckIfDead())
        {
            deathLogic.Die();
        }
        if(attackLogic != null)
        {
            attackLogic.DealDamage(collision);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackLogic != null)
        {
            attackLogic.DealDamage(collision);
        }
    }

    void FixedUpdate()
    {
        if(movementLogic != null)
        {
            movementLogic.Move(IMoveable.MoveDirections.Any);
        }
    }
}
