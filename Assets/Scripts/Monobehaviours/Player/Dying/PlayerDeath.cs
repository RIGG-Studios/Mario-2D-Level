using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour, IKillable
{
    public float maxHealth;
    public float maxLives;
    public Vector3 spawnPosition;

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
            SceneManager.LoadScene("Menu");
        }
        else
        {
            currentLives--;
            currentHealth = maxHealth;
            transform.position = spawnPosition;
        }
    }

    void Awake()
    {
        currentHealth = maxHealth;
        currentLives = maxLives;
    }
}
