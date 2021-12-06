using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAttack : MonoBehaviour, IAttackable
{
    public float damage;
    public void DealDamage(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IKillable>() != null)
        {
            if(collision.gameObject.transform.position.y <= transform.position.y)
            {
                collision.gameObject.GetComponent<IKillable>().TakeDamage(damage);
            }
        }
    }
}
