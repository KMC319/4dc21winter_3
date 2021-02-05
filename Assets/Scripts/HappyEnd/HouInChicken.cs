using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HouInChicken : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = new Vector2(speed, rb.velocity.y);
        transform.Translate(v);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Finish")
        {

            Destroy(gameObject);
        }
    }
}
