using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaDeath : MonoBehaviour, IKillable
{
    public AudioSource deathSoundSource;
    Animator goombaAnimator;

    private void Start()
    {
        goombaAnimator = GetComponent<Animator>();
    }

    public bool CheckIfDead()
    {
        return false;
    }

    public void Die()
    {
        goombaAnimator.SetTrigger("Die");
        deathSoundSource.Play();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        Die();
    }
}
