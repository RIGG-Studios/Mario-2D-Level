using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOp1 : MonoBehaviour, IMoveable
{
    //Ground speed
    public float speed;
    //Jump height
    public float jumpHeight;
    //Jetpack speed when the player is going straight up
    public float neutralAirSpeed;
    //Speed when the player is moving in a direction midair
    public float directionalAirSpeed;

    //Time until the apex of the jump
    public float timeTillJumpApex;
    //Time until the jump lands
    public float timeTillJumpLand;
    //Gravity when the player falls
    public float fallingGravity;

    //If the player presses space before they touch the ground, but they do it close to the ground it still jumps, increase this to increase that tolorence
    public float jumpForgiveness;
    //Time the player has to hold space before the jetpack activates
    public float timeTillJetpackActivate;

    //Jump sound
    public AudioClip jumpSound;
    //Jetpack sound
    public AudioClip jetpackSound;

    Animator anim;

    //Jetpack fuel amount
    public float jetpackFuel;
    //Max jetpack fuel amount
    public float maxJetpackFuel;
    //Max jetpack depletion speed
    public float jetpackDepletionSpeed;

    //is moving right
    bool isMovingRight;
    //is moving left
    bool isMovingLeft;
    //is grounded
    bool isGrounded;
    //is jetpacking
    bool isJetpacking;

    //is holding space
    bool isHoldingSpace;
    //is currently jumping
    bool isCurrentlyJumping;

    //jump timer
    float jumpTimer;
    //time held space
    float timeHeldSpace;

    //the first jump
    bool firstJump;

    //rigidbody
    new Rigidbody2D rigidbody;

    //audiosource that plays audio from
    AudioSource audioSource;

    //direction the player moves in
    Vector2 forceVector;

    void Start()
    {
        //Gets the rigidbody, audiosource, and sets the jetpackFuel variable
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        jetpackFuel = maxJetpackFuel;
        anim = GetComponent<Animator>();
    }

    //Main move function, called from playermanager, uses a movedirection to move a certain direction
    public void Move(IMoveable.MoveDirections moveDirection)
    {
        //Moving left, rotates the sprite to face left and sets ismovingleft to true while the button is held down
        if (moveDirection == IMoveable.MoveDirections.Left)
        {
            isMovingLeft = !isMovingLeft;

            if (isMovingLeft)
            {
                transform.rotation = new Quaternion(0, -180, 0, 0);
            }
        }

        //Moving right, rotates the sprite to face right and sets ismovingright to true while the button is held down
        else if (moveDirection == IMoveable.MoveDirections.Right)
        {
            isMovingRight = !isMovingRight;

            if (isMovingRight)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

        //Jumping
        else if (moveDirection == IMoveable.MoveDirections.Jump)
        {
            //First jump checks if the player pressed space or just let go of space after holding it, if the later its true, former is false
            firstJump = !firstJump;

            //If the player is not on the ground, jetpacking, and just let go of space
            if (!firstJump && !isGrounded && isJetpacking)
            {
                isJetpacking = false;
            }

            //If the player pressed space or has not let go of space yet
            if (firstJump)
            {
                //Sets holding space to true while the player is holding space
                isHoldingSpace = true;

                //If not is grounded, sets the jumptimer to the current time
                if (!isGrounded)
                {
                    jumpTimer = Time.time;
                }

                //If is grounded and is not currently jumping
                if (isGrounded && !isCurrentlyJumping)
                {
                    //Plays the jump audio, and starts the jump coroutine, so the player can jump 
                    audioSource.clip = jumpSound;
                    audioSource.Play();
                    StartCoroutine("jumpCoroutine");
                }
            }

            //If the player has let go of space then set isholdingspace to false
            else
            {
                isHoldingSpace = false;
            }
        }
    }

    //Jump coroutine, makes the player jump
    public IEnumerator jumpCoroutine()
    {
        //Set jump timer to zero, set isgrounded to false, iscurrentlyjumping to true, add a jump force, and wait a small amount of time
        jumpTimer = 0;
        isGrounded = false;
        isCurrentlyJumping = true;
        forceVector.y = jumpHeight * 10;
        yield return new WaitForSeconds(0.1f);

        //Reset forcevector
        forceVector.y = 0;

        //Wait until the player reaches the apex of their jump
        yield return new WaitForSeconds(timeTillJumpApex);

        //Set the gravity to falling gravity, so the player falls faster than they go up and wait until they land
        rigidbody.gravityScale = fallingGravity;
        yield return new WaitForSeconds(timeTillJumpLand);

        //When landed, set the gravity back to normal and iscurrentlyjumping to false
        rigidbody.gravityScale = 1;
        isCurrentlyJumping = false;
    }


    //When the player collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If the player lands on the ground
        if (collision.collider.tag == "Ground")
        {
            //If the player lands on the ground from directly above the y axis and a certain distance from the player
            for (int i = 0; i < collision.contacts.Length; i++)
            {
                if (collision.contacts[i].normal.y > 0.5f)
                {
                    //Sets isgrounded to true and sets the player's rotation, so they don't stay leaning after they used the jetpack and landed
                    isGrounded = true;
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }

            //If the current time minus the jumptimer is less than jump forgiveness and jumptimer is not 0 and isgrounded
            if ((Time.time - jumpTimer) <= jumpForgiveness && jumpTimer != 0 && isGrounded)
            {
                //Jump
                StartCoroutine("jumpCoroutine");
            }
        }
    }

    //Physics update loop
    void FixedUpdate()
    {
        //If moving left
        if (isMovingLeft)
        {
            //If the player is on the ground
            if (isGrounded)
            {
                //Set the forcevector so that the player moves to the left by speed
                forceVector.x = -speed * 500 * Time.deltaTime;
            }

            //If the player is not on the ground
            else
            {
                //Set the forcevector so that the player moves to the left by airspeed
                forceVector.x = -directionalAirSpeed * 500 * Time.deltaTime; 
            }
        }

        //If moving right
        if (isMovingRight)
        {
            //If the player is on the ground
            if (isGrounded)
            {
                //Set the forcevector so that the player moves to the right by speed
                forceVector.x = speed * 500 * Time.deltaTime;
            }
            else
            {
                //Set the forcevector so that the player moves to the right by airspeed
                forceVector.x = directionalAirSpeed * 500 * Time.deltaTime;
            }
        }

        //If not isjetpacking
        if (!isJetpacking)
        {
            //If the forcevector.y is not equal to jumpheight and forcevector.y is not 0
            if (forceVector.y != jumpHeight * 10 && forceVector.y != 0)
            {
                //Set forcevector.y to zero and turn off the audio
                forceVector.y = 0;
                audioSource.loop = false;

                //If not isgrounded set gravity to falling gravity
                if (!isGrounded)
                {
                    rigidbody.gravityScale = fallingGravity;
                }
            }
        }

        //Else if isjetpacking and jetpackfuel is above 0
        else if (isJetpacking && jetpackFuel > 0)
        {
            //Decrease jetpackfuel by jetpackdepletionspeed
            jetpackFuel -= jetpackDepletionSpeed * Time.deltaTime;

            //If the audioclip isn't the jetpack sound and it isn't looping
            if (audioSource.clip != jetpackSound || audioSource.loop == false)
            {
                //Set the audioclip to jetpacksound, turn on looping and play the audio
                audioSource.clip = jetpackSound;
                audioSource.loop = true;
                audioSource.Play();
            }

            //Set the forcevector.y to neutralairspeed/jetpackforce and reset the gravity to its default amount
            forceVector.y = neutralAirSpeed * 500 * Time.deltaTime;
            rigidbody.gravityScale = 1;
        }

        //If isgrounded
        if (isGrounded)
        {
            //Set isjetpacking to false and sets the gravityscale to default
            isJetpacking = false;
            rigidbody.gravityScale = 1;
        }

        //If isholdingspace
        if (isHoldingSpace)
        {
            //Increment timeheldspace
            timeHeldSpace += Time.deltaTime;
        }

        //Else if not isholdingspace
        else if (!isHoldingSpace)
        {
            //Reset timeheldspace to zero
            timeHeldSpace = 0;
        }

        //If the player holds space for longer than the time it takes to activate the jetpack
        if (timeHeldSpace > timeTillJetpackActivate)
        {
            //Set isjetpacking to true, and isgrounded to false, and timeheldspace to zero
            isJetpacking = true;
            isGrounded = false;
            timeHeldSpace = 0;
        }

        //Add the forcevector to the rigidbody with acceleration force and after reset the x value of forcevector
        rigidbody.AddForce(forceVector, ForceMode2D.Force);
        forceVector.x = 0;
    }

    //Update loop
    void Update()
    {
        //If isjetpacking
        if (isJetpacking)
        {
            anim.SetBool("Jetpacking", true);
            //If ismovingleft
            if (isMovingLeft)
            {
                //Tilt to the left
                transform.rotation = Quaternion.Euler(0, -180, -22);
            }

            //Else if ismovingright
            else if (isMovingRight)
            {
                //Tilt to the right
                transform.rotation = Quaternion.Euler(0, 0, -22);
            }

            //Else
            else
            {
                //Don't tilt
                transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.SetBool("Jetpacking", false);
            }
        }
        if ((isMovingLeft || isMovingRight) && isGrounded)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
        if (isCurrentlyJumping)
        {
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Jumping", false);
        }
    }
}
