using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GroundCheck ground;

    public float speed = 8f;
    public float moveableRange = 5.5f;
    public float jumppower = 10f;
    public float accel = 0.0f;

    private Animator anim = null;
    private Rigidbody2D rb = null;
    [SerializeField] ContactFilter2D filter2d;

    void Start()
    {
        anim = GetComponent<Animotor>();
        rb = GetComponent < Rigidbody2D.();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //move and stay
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        if(horizontalKey>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("move",true);
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
        rb.velocity = new Vector2(xSpeed, rb.velocity.y)

        //jump
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rigid2d.AddForce(transform.up * jumppower);
        }

        //jump length reset
        if (GetComponent<Rigidbody2D>().IsTouching(filter2d))
        {
            rigid2d = GetComponent<Rigidbody2D>();
            rigid2d.velocity = Vector2.zero;
        }

    }
}
