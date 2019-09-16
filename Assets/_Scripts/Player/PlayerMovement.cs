using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //movement variables
    public float JumpForce;
    public float JumpTime;
    private float JumpTimeCounter;
    private bool StoppedJumping;
    private bool CanDoubleJump;


    public float MoveSpeed;

    public float SpeedMultiplier;

    public float SpeedIncreaseMilestone;

    private float SpeedMileStoneCount;

    public float MaxMoveSpeed;


    //other variables
    private Rigidbody2D PlayerRB;
    public bool Grounded;
    public LayerMask GroundLayer;
    public Transform GroundCheck;
    public float GroundCheckRadius;


    public GameManagerScript GMScript;

    //private Collider2D PlayerCollider;
    private Animator PlayerAnimator;

    //sound variables
    public AudioSource JumpSound;
    public AudioSource DeathSound;
    
    // Use this for initialization
	void Start ()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        //PlayerCollider = GetComponent<Collider2D>();
        PlayerAnimator = GetComponent<Animator>();
        JumpTimeCounter = JumpTime;

        SpeedMileStoneCount = SpeedIncreaseMilestone;
        
	}

    // Update is called once per frame
    void Update()
    {
        Grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer); //Gives boolen value if Player Collider is toching the ground.

        PlayerRB.velocity = new Vector2(MoveSpeed, PlayerRB.velocity.y);

        if(transform.position.x > SpeedMileStoneCount )
        {
            SpeedMileStoneCount += SpeedIncreaseMilestone;
            SpeedIncreaseMilestone += (SpeedIncreaseMilestone * SpeedMultiplier)/2;
            MoveSpeed = MoveSpeed * SpeedMultiplier;
        }
        
        if(MoveSpeed > MaxMoveSpeed)
        {
            MoveSpeed = MaxMoveSpeed;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Grounded)
            {
                PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, JumpForce);
                StoppedJumping = false;
                JumpSound.Play();
            }

            if(!Grounded && CanDoubleJump)
            {
                JumpTimeCounter = JumpTime/2;
                PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, JumpForce);
                CanDoubleJump = false;
                StoppedJumping = false;
                JumpSound.Play();
            }
        }

        if (Input.GetMouseButton(0) && !StoppedJumping)
        {
            if (JumpTimeCounter > 0)
            {
                PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, JumpForce);
                JumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            JumpTimeCounter = 0;
            StoppedJumping = true;
        }

        if (Grounded)
        {
            JumpTimeCounter = JumpTime;
            CanDoubleJump = true;
        }

        PlayerAnimator.SetFloat("Speed", PlayerRB.velocity.x);
        PlayerAnimator.SetBool("isGrounded", Grounded);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "KillBox")
        {
            GMScript.RestartGame();
            DeathSound.Play();
        }
    }

}
