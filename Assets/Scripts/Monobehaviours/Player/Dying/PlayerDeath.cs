using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour, IKillable
{
    public float maxHealth;
    public float maxLives;

    float currentLives;
    float currentHealth;

    public bool CheckIfDead()
    {
        if(currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Die()
    {
        Respawn();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void Respawn()
    {
        if(currentLives <= 0)
        {
            Debug.Log("Game over");
        }
        else
        {
            currentLives--;
            Debug.Log("Respawned");
        }
    }

    void Awake()
    {
        currentHealth = maxHealth;
        currentLives = maxLives;
    }
}
