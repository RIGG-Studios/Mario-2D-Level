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
        if (GetComponent<IMoveable>() != null) 
        { 
            movementLogic = GetComponent<IMoveable>(); 
        }

        if(GetComponent<IKillable>() != null)
        {
            deathLogic = GetComponent<IKillable>();
        }

        if(GetComponent<IAttackable>() != null)
        {
            attackLogic = GetComponent<IAttackable>();
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

    void FixedUpdate()
    {
        if(movementLogic != null)
        {
            movementLogic.Move(IMoveable.MoveDirections.Any);
        }
    }
}
