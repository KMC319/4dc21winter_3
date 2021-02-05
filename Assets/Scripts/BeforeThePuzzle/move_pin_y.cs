using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_pin_y : MonoBehaviour
{
    private Vector3 screenpoint;
    private Vector3 offSet;
    Rigidbody2D rb;

    private Vector2 startPos;
    // Start is called before the first frame update
    void Start() {
        startPos = transform.position;
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if ((transform.position.y -startPos.y) * Mathf.Sign(transform.lossyScale.y) > 0) {
            rb.velocity = Vector2.zero;
            transform.position = startPos;
        }
    }
    /*void OnMouseDown()
     {
         this.screenpoint = Camera.main.WorldToScreenPoint(transform.position);
         this.offSet = Camera.main.ScreenToWorldPoint(new Vector3(screenpoint.x, Input.mousePosition.y, screenpoint.z)) - transform.position;
         this.rb.velocity = this.offSet;
     }*/

    private void OnMouseDrag()
    {
        if ((transform.position.y - startPos.y) * Mathf.Sign(transform.lossyScale.y) >= 0) {
            rb.velocity = new Vector3(0, Mathf.Sign(Input.GetAxisRaw("Mouse Y")) * 200, 0);
        }
    }

    //rb.velocity = new Vector3(Input.GetAxisRaw("Mouse Y") * 0,100, 0);

}
