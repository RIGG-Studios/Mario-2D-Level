using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackFuelingStationAttack : MonoBehaviour, IAttackable
{
    public float jetpackRefuelSpeed;

    public void DealDamage(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementOp1>())
        {
            PlayerMovementOp1 playerMovement = collision.gameObject.GetComponent<PlayerMovementOp1>();

            if(playerMovement.jetpackFuel < playerMovement.maxJetpackFuel)
            {
                playerMovement.jetpackFuel += jetpackRefuelSpeed * Time.deltaTime;
            }
            else
            {
                playerMovement.jetpackFuel = playerMovement.maxJetpackFuel;
            }
        }
    }

}
