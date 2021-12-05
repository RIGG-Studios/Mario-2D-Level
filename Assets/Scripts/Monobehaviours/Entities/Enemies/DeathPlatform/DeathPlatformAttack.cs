using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlatformAttack : MonoBehaviour, IAttackable
{
    public void DealDamage(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<IKillable>() != null)
        {
            collision.gameObject.GetComponent<IKillable>().TakeDamage(1000);
        }
    }
}
