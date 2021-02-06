using System.Collections;
using System.Collections.Generic;
using Action;
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


    private Rigidbody2D rb = null;
    private ActionController actionController;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    public bool IsActive;
    private bool isGround = false;
    private bool isJump = false;
    private bool isMuteki = false;

    public void OnActive(ActionController controller) {
        actionController = controller;
        IsActive = true;
        isMuteki = false;
    }
    
    private IEnumerator Accel()
    {
        accel = 400.0f;
        yield return new WaitForSeconds(5f);
        accel = 0.0f;
    }

    private Color normalColor = Color.white;
    private Color mutekiColor = new Color(1, 1, 1, 0.8f);
    private IEnumerator Muteki()
    {
        if (isMuteki)
        {
            yield break;
        }
        isMuteki = true;
        for(int j = 0; j < 10; j++)
        {
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = mutekiColor;
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = normalColor;
        }

        isMuteki = false;
    }

    void Start() {
        isMuteki = true;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    


    // Update is called once per frame
    void Update()
    {
        if(!IsActive) return;
        //get judge ground
        isGround = ground.IsGround();
        anim.SetBool("IsGround", isGround);

        //move and stay
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        float ySpeed = rb.velocity.y;

        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1)*0.3f;
            xSpeed = speed + accel;
            anim.SetBool("Walk", true);
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1)*0.3f;
            xSpeed = -speed - accel;
            anim.SetBool("Walk", true);
        }
        else
        {
            xSpeed = 0.0f;
            anim.SetBool("Walk", false);
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
            anim.SetTrigger("Jump");
            ySpeed = jumppower + (accel / 2);
            rb.velocity = new Vector2(xSpeed, ySpeed);
            isJump = false;
        }

        //yakitori
        if (actionController.yakitori > 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                actionController.yakitori--;
                StartCoroutine (Accel());
            }
        }

        //toripack
        if (actionController.toripack > 0)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                actionController.toripack--;
                StartCoroutine(Muteki());
            }
        }

    }

    //damage
    private void OnCollisionEnter2D(Collision2D collision) {
        if (isMuteki) return;
        if (collision.collider.tag == "HotGimmick") {
            actionController.Dead(PlayerDeadType.Hot);
            Destroy(this);
        }else if (collision.collider.tag == "ColdGimmick") {
            actionController.Dead(PlayerDeadType.Cold);
            Destroy(this);
        }
    }
}
