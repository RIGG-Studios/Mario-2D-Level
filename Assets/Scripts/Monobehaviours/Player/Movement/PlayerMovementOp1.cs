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
<<<<<<< Updated upstream
    public float rotationAmount;
=======

    public float jumpForgiveness;
    public float timeTillJetpackActivate;

    public float terminalVelocity;
    public float maxUpwardsVelocity;
    public float maxSpeed;

    public AudioClip jumpSound;
    public AudioClip jetpackSound;
>>>>>>> Stashed changes

    bool isMovingRight;
    bool isMovingLeft;
    bool isGrounded;
    bool isJetpacking;

    bool firstJump;

    new Rigidbody2D rigidbody;

    Vector2 forceVector;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(IMoveable.MoveDirections moveDirection)
    {
        if (moveDirection == IMoveable.MoveDirections.Left)
        {
<<<<<<< Updated upstream
            isMovingLeft = !isMovingLeft; 
=======
            isMovingLeft = !isMovingLeft;

            if (isMovingLeft)
            {
                transform.rotation = new Quaternion(0, -180, 0, 0);
            }
>>>>>>> Stashed changes
        }
        else if (moveDirection == IMoveable.MoveDirections.Right)
        {
            isMovingRight = !isMovingRight;
<<<<<<< Updated upstream
=======

            if (isMovingRight)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
>>>>>>> Stashed changes
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
                if (!isGrounded)
                {
                    isJetpacking = !isJetpacking;
                }
                if (isGrounded)
                {
                    isGrounded = false;
                    StartCoroutine("jumpCoroutine");
                }
            }
        }
    }

    public IEnumerator jumpCoroutine()
    {
        forceVector.y = jumpHeight * 10;
        yield return new WaitForSeconds(0.1f);
        forceVector.y = 0;
        yield return new WaitForSeconds(timeTillJumpApex);
        rigidbody.gravityScale = fallingGravity;
        yield return new WaitForSeconds(timeTillJumpLand);
        rigidbody.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.contacts[i].normal.y > 0.5f)
                {
<<<<<<< Updated upstream
                    isGrounded = true; 
=======
                    isGrounded = true;
                    transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
>>>>>>> Stashed changes
                    //Checks is grounded within a certain distance of the collider to prevent early activation of the jetpack
                }
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
                if (!isGrounded)
                {
                    rigidbody.gravityScale = fallingGravity;
                }
            }
        }
        else if (isJetpacking)
        {
            forceVector.y = neutralAirSpeed * 500 * Time.deltaTime;
            rigidbody.gravityScale = 1;
        }
        if (isGrounded)
        {
            isJetpacking = false;
            rigidbody.gravityScale = 1;
        }

<<<<<<< Updated upstream
        rigidbody.AddForce(forceVector);
=======
        if (timeHeldSpace > timeTillJetpackActivate)
        {
            isJetpacking = true;
            isGrounded = false;
            timeHeldSpace = 0;
        }

        rigidbody.AddForce(forceVector, ForceMode2D.Force);
>>>>>>> Stashed changes
        forceVector.x = 0;

        rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rigidbody.velocity.y, terminalVelocity, maxUpwardsVelocity));
    }
    void Update()
    {
        if (!isGrounded || isJetpacking)
        {
            if (isMovingLeft)
            {
<<<<<<< Updated upstream
                transform.rotation = Quaternion.Euler(0, 0, 22);
                Debug.Log("It fucking worked left");
=======
                transform.rotation = Quaternion.Euler(0, -180, -22);
>>>>>>> Stashed changes
            }
            else if (isMovingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, -22);
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, 0);
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("It fucking worked ground");
        }
        //This entire thing was a clusterfuck. Update sets it to a fixed angle when the conditions are met
    }
}
