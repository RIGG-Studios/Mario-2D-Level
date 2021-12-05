using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaDeath : MonoBehaviour, IKillable
{
    public AudioSource deathSoundSource;

    public bool CheckIfDead()
    {
        return false;
    }

    public void Die()
    {
        deathSoundSource.Play();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        Die();
        Debug.Log("Killed goomba");
    }
}
