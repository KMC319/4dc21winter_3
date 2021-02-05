using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GroundCheck ground;
    public GroundCheck head;

    public float speed = 8.0f;
    public float gravity = 3.0;
    public float jumppower = 10.0f;
    public float jumpCount=0;
    public const int jumpMax = 10;
    public float accel = 0.0f;

    private Animator anim = null;
    private Rigidbody2D rb = null;

    private bool isGround = false;
    private bool isHead = false;
    private bool isJump = false;
    private float jumpTime = 0.0f;

    void Start()
    {
        anim = GetComponen <Animotor>();
        rb = GetComponent<Rididbody2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //get judge ground
        isGround = ground.IsGround();
        isHead = head.IsGround();

        //move and stay
        float horizontalKey = Input.GetAxis("Horizontal");
        float jumpKey = Input.GetKeyDown(KeyCode.LeftShift);
        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("move", true);
            xSpeed = speed + accel;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("move", true);
            xSpeed = -speed - accel;
        }
        else
        {
            anim.SetBool("move", false);
            xSpeed = 0.0f;
        }
        anim.SetBool("jump", isJump);
        anim.SetBool("ground", isGround);
        rb.velocity = new Vector2(xSpeed, ySpeed);

        //jump
        
        if(isGround)
        {
            jumpCount = 0;
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                isJump = true;
            }
        }

        if (isJump)
        {
            ySpeed = jumppower + (accel / 2) - 0.5 * jumpCount;
            if (jumpCount < jumpMax)
            {
                jumpCount++;
            }
            isJump = false;
        }

    }
}
