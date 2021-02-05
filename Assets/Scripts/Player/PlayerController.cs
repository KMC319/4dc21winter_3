using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GroundCheck ground;

    public float speed = 800.0f;
    public float gravity = 200.0f;
    public float jumppower = 800.0f;
    public int jumpCount;
    public int jumpMax = 10;
    public float accel = 0.0f;

    public int yakitori;
    public int toripack;
    public int Life;

    private Rigidbody2D rb = null;
    private string enemyTag = "Enemy";


    private bool isGround = false;
    private bool isJump = false;
    private bool isMuteki = false;

    private IEnumerator Accel()
    {
        accel = 400.0f;
        yield return new WaitForSeconds(5f);
        accel = 0.0f;
    }

    private IEnumerator Muteki()
    {
        if (isMuteki)
        {
            yield break;
        }
        isMuteki = true;
        for(int j = 0; j < 3; j++)
        {
            yield return new WaitForSeconds(0.1f);
        }

    }

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
            jumpCount = 3;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
            }
            else
            {
                isJump = false;
            }
        }
        else if (jumpCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
                jumpCount = jumpCount - 1;
            }
        }
        if (isJump)
        {
            ySpeed = jumppower + (accel / 2);
            rb.velocity = new Vector2(xSpeed, ySpeed);
            isJump = false;
        }

        //yakitori
        if (yakitori > 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                yakitori--;
                StartCoroutine (Accel());
            }
        }

        if (toripack > 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                toripack--;
                StartCoroutine(Muteki());
            }
        }

    }

    //damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            Life--;
            StartCoroutine(Muteki());
        }
    }

}
