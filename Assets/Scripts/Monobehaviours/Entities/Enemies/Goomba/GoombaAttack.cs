using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaAttack : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<IKillable>() != null)
        {
            collision.gameObject.GetComponent<IKillable>().TakeDamage(damage);
        }
    }
}
