using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    
    private float moveInput;
    private bool facingRight = true;

    private Rigidbody2D rb;

    //Code to check if player is grounded
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //Coyote Timer
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    //Jump Buffering
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    //Sound setup(jump)
    public AudioSource src;
    public AudioClip jumpSound;

    //Animation
    [SerializeField]
    private Animator animator;

    //Platform
    public bool isOnPlatform;
    public Rigidbody2D platformRb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");

        if (isOnPlatform)
        {
            rb.velocity = new Vector2(moveInput * speed + platformRb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

        //Animation
        if(moveInput == 0)
        {
            animator.SetBool("isMoving",false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }


        if (facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            flip();
        }

    }

    void Update()
    {
        //Coyote Time
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
            //Animation
            animator.SetBool("groundCheck",true);
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            //Animation
            animator.SetBool("groundCheck", false);
        }
        //End Coyote Time

        //Jump Buffer
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        //End Jump Buffer
        
        //Jump thing.
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f && PlayerPrefs.GetInt("paused") == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x ,jumpForce);
            
            //Animation
            animator.SetBool("isJumping", true);

            //Check if player is running:
            // 1 is running , 0 is paused
            if (PlayerPrefs.GetInt("paused") == 1)
            {
                //Sound
                src.clip = jumpSound;
                src.Play();
            }

            jumpBufferCounter = 0f;
        }
        
        //Cut jumping...
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && PlayerPrefs.GetInt("paused") == 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
        
        if(rb.velocity.y < 0f)
        {
            animator.SetBool("isJumping", false);
        }

    }
    private void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}


