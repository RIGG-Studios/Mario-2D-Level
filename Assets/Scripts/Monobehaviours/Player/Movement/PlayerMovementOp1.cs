using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOp1 : MonoBehaviour, IMoveable
{
    public float speed;
    public float jumpHeight;
    public float neutralAirSpeed; //For direct vertical movement with the jetpack
    public float directionalAirSpeed; //For vertical + horizontal movement with the jetpack

    public float timeTillJumpApex;
    public float timeTillJumpLand;
    public float fallingGravity;

    public float jumpForgiveness;
    public float timeTillJetpackActivate;

    public AudioClip jumpSound;
    public AudioClip jetpackSound;

    bool isMovingRight;
    bool isMovingLeft;
    bool isGrounded;
    bool isJetpacking;

    bool isHoldingSpace;
    bool isCurrentlyJumping;

    float jumpTimer;
    float timeHeldSpace;

    bool firstJump;

    new Rigidbody2D rigidbody;

    AudioSource audioSource;

    Vector2 forceVector;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Move(IMoveable.MoveDirections moveDirection)
    {
        if (moveDirection == IMoveable.MoveDirections.Left)
        {
            isMovingLeft = !isMovingLeft;

            if (isMovingLeft)
            {
                transform.rotation = new Quaternion(0, -180, 0, 0);
            }
        }
        else if (moveDirection == IMoveable.MoveDirections.Right)
        {
            isMovingRight = !isMovingRight;

            if (isMovingRight)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
        else if (moveDirection == IMoveable.MoveDirections.Jump)
        {
            firstJump = !firstJump;

            if (!firstJump && !isGrounded && isJetpacking)
            {
                isJetpacking = false;
            }
            if (firstJump)
            {
                isHoldingSpace = true;

                if (!isGrounded)
                {
                    jumpTimer = Time.time;
                }
                if (isGrounded && !isCurrentlyJumping)
                {
                    audioSource.clip = jumpSound;
                    audioSource.Play();
                    StartCoroutine("jumpCoroutine");
                }
            }
            else
            {
                isHoldingSpace = false;
            }
        }
    }

    public IEnumerator jumpCoroutine()
    {
        jumpTimer = 0;
        isGrounded = false;
        isCurrentlyJumping = true;
        forceVector.y = jumpHeight * 10;
        yield return new WaitForSeconds(0.1f);
        forceVector.y = 0;
        yield return new WaitForSeconds(timeTillJumpApex);
        rigidbody.gravityScale = fallingGravity;
        yield return new WaitForSeconds(timeTillJumpLand);
        rigidbody.gravityScale = 1;
        isCurrentlyJumping = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.contacts[i].normal.y > 0.5f)
                {
                    isGrounded = true;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    //Checks is grounded within a certain distance of the collider to prevent early activation of the jetpack
                }
            }

            if ((Time.time - jumpTimer) <= jumpForgiveness && jumpTimer != 0 && isGrounded)
            {
                StartCoroutine("jumpCoroutine");
            }
        }
    }

    void FixedUpdate()
    {
        if (isMovingLeft)
        {
            if (isGrounded)
            {
                forceVector.x = -speed * 500 * Time.deltaTime;
                //Sets speed for ground movement. Reminder to increase it after testing
            }
            else
            {
                forceVector.x = -directionalAirSpeed * 500 * Time.deltaTime; 
                //Changes speed for mid air. Reminder to set it to a more reasonable value after testing is finished
            }
        }
        if (isMovingRight)
        {
            if (isGrounded)
            {
                forceVector.x = speed * 500 * Time.deltaTime;
            }
            else
            {
                forceVector.x = directionalAirSpeed * 500 * Time.deltaTime;
            }
        }

        if (!isJetpacking)
        {
            if (forceVector.y != jumpHeight * 10 && forceVector.y != 0)
            {
                forceVector.y = 0;
                audioSource.loop = false;

                if (!isGrounded)
                {
                    rigidbody.gravityScale = fallingGravity;
                }
            }
        }
        else if (isJetpacking)
        {
            if(audioSource.clip != jetpackSound || audioSource.loop == false)
            {
                audioSource.clip = jetpackSound;
                audioSource.loop = true;
                audioSource.Play();
            }

            forceVector.y = neutralAirSpeed * 500 * Time.deltaTime;
            rigidbody.gravityScale = 1;
        }
        if (isGrounded)
        {
            isJetpacking = false;
            rigidbody.gravityScale = 1;
        }
        if (isHoldingSpace)
        {
            timeHeldSpace += Time.deltaTime;
        }
        else if (!isHoldingSpace)
        {
            timeHeldSpace = 0;
        }

        if (timeHeldSpace > timeTillJetpackActivate)
        {
            isJetpacking = true;
            isGrounded = false;
            timeHeldSpace = 0;
        }


        rigidbody.AddForce(forceVector, ForceMode2D.Force);
        forceVector.x = 0;
    }
    void Update()
    {
        if (isJetpacking)
        {
            if (isMovingLeft)
            {
                transform.rotation = Quaternion.Euler(0, -180, -22);
            }
            else if (isMovingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, -22);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        //This entire thing was a clusterfuck. Update sets it to a fixed angle when the conditions are met
    }

    public float GetSpeed()
    {
        return speed+10; 
        //Camera speed. +10 for adjustment in gravity scale and player speed. Not very good for vertical movement
        //It's honestly a terrible implementation but it's good for now
    }
}
