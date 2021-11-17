using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttackable
{
    public int enemyLayer;
    public float damage;

    public void DealDamage(Collision2D collision)
    {
        if(collision.gameObject.layer == enemyLayer)
        {
            IKillable enemyKillable = collision.gameObject.GetComponent<IKillable>();

            if(enemyKillable != null)
            {
                for (int i = 0; i < collision.contacts.Length; i++)
                {
                    if (collision.contacts[i].normal.y > 0.5f)
                    {
                        enemyKillable.TakeDamage(damage);
                        break;
                    }
                }
            }
        }
    }
}
