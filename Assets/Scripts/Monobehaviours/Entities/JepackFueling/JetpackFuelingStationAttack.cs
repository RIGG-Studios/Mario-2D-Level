using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackFuelingStationAttack : MonoBehaviour, IAttackable
{
    public float jetpackRefuelSpeed;
    Animator jetpackFuelingPlatformAnimator;
    ParticleSystem jetpackFuelingParticles;

    void Start()
    {
        jetpackFuelingPlatformAnimator = transform.parent.GetComponent<Animator>();
        jetpackFuelingParticles = transform.parent.GetChild(0).GetComponent<ParticleSystem>();
    }

    public void DealDamage(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementOp1>())
        {
            jetpackFuelingPlatformAnimator.SetBool("Fueling", true);
            jetpackFuelingParticles.Play();

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementOp1>())
        {
            jetpackFuelingPlatformAnimator.SetBool("Fueling", false);
            jetpackFuelingParticles.Stop();
        }
    }

}
