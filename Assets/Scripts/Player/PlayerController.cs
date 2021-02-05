using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GroundCheck ground;

    public float speed = 80.0f;
    public float gravity = 3.0f;
    public float jumppower = 10.0f;
    public float accel = 0.0f;

    private Rigidbody2D rb = null;


    private bool isGround = false;
    private bool isJump = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        //get judge ground
        isGround = ground.IsGround();

        //move and stay
        float horizontalKey = Input.GetAxis("Horizontal");
        float jumpKey = Input.GetAxis("Vertical");
        float xSpeed = 0.0f;
        float ySpeed = rb.velocity.y;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1)*0.3f;
            xSpeed = speed + accel;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1)*0.3f;
            xSpeed = -speed - accel;
        }
        else
        {
            xSpeed = 0.0f;
        }

        rb.velocity = new Vector2(xSpeed, ySpeed);


        //jump

        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
            }
            else
            {
                isJump = false;
            }
        }
        if (isJump)
        {
            ySpeed = jumppower + (accel / 2);
            rb.velocity = new Vector2(xSpeed, ySpeed);
            isJump = false;
        }


    }


}
