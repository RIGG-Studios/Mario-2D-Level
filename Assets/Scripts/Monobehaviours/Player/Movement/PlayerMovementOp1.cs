using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOp1 : MonoBehaviour, IPlayerMovable
{
    public float speed;
    public float jumpHeight;
    public float jetpackPower;
    public float midAirSpeed;

    public float timeTillJumpApex;
    public float timeTillJumpLand;
    public float fallingGravity;

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

    public void Move(IPlayerMovable.MoveDirections moveDirection)
    {
        if (moveDirection == IPlayerMovable.MoveDirections.Left)
        {
            isMovingLeft = !isMovingLeft;
        }
        else if (moveDirection == IPlayerMovable.MoveDirections.Right)
        {
            isMovingRight = !isMovingRight;
        }
        else if (moveDirection == IPlayerMovable.MoveDirections.Jump)
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

    IEnumerator jumpCoroutine()
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
                    isGrounded = true;
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
            }
            else
            {
                forceVector.x = -midAirSpeed * 500 * Time.deltaTime;
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
                forceVector.x = midAirSpeed * 500 * Time.deltaTime;
            }
        }
        if (!isJetpacking)
        {
            if (forceVector.y != jumpHeight && forceVector.y != 0)
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
            forceVector.y = jetpackPower * 500 * Time.deltaTime;
            rigidbody.gravityScale = 1;
        }
        if (isGrounded)
        {
            isJetpacking = false;
            rigidbody.gravityScale = 1;
        }

        rigidbody.AddForce(forceVector);
        forceVector.x = 0;
    }
}
