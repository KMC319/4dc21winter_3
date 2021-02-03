using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// http://yadukkii.hateblo.jp/entry/2015/10/05/235559
// https://qiita.com/mczkzk/items/de8b019f7ef3b4044bf7

public class MeteorScript : MonoBehaviour
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
