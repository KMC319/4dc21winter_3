using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dammy_Player : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var v = new Vector2(speed, rb.velocity.y);
        transform.Translate(v);
    }
}
