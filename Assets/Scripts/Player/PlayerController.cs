using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2d;
    public float speed = 8f;
    public float moveableRange = 5.5f;
    public float jumppower = 10f;
    private Vector2 velocity;
    [SerializeField] ContactFilter2D filter2d;
}


    // Update is called once per frame
    void Update()
    {
        //move
        transform.Translate(Imput.GetAxisRaw(
            "Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.position = new Vector2(Mathf.Clamp(
            transform.position.x, -moveableRange, moveableRange),
            transform.posotion.y);

        //jump
        if(Input.GetKeyDown(KeyCode.Shift))
        {
            rigid2d.AddForce(transform.up * jumppower);
        }

        //jump length reset
        if(GetComponent<Rigidbody2D>().IsTouching(filter2d))
        {
            rigid2d = GetComponent<Rigidbody2D>();
            rigid2d.velocity = Vector2.zero;
        }
    }
