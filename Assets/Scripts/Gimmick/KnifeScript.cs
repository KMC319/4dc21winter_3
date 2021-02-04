using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public float timer = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        var v = new Vector2(speed, rb.velocity.y);
        transform.Translate(v);
    }
}
