using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaDeath : MonoBehaviour, IKillable
{
    public bool CheckIfDead()
    {
        return false;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        Die();
        Debug.Log("Killed goomba");
    }
}
