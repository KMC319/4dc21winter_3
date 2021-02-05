using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_pin : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 tyousei;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // ’Ç‰Á
    void OnMouseDown()
    {
       // this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
       // this.offset = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z))- transform.position;
        //this.rb.velocity = this.offset;
        // Debug.Log(offset);
    }
    void OnMouseDrag()
    {

        
        rb.velocity = new Vector3(Input.GetAxisRaw("Mouse X") * 200, 0, 0);
    }
}
    // ’Ç‰Á
    /*void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
        Debug.Log(currentScreenPoint);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
         Debug.Log(currentPosition);
         Vector3 Test_currentPosition = currentPosition;
        Vector3 real_currentPosition = Test_currentPosition - currentPosition;
         Debug.Log(Test_currentPosition);
        this.rb.velocity = currentPosition;
        transform.position = currentPosition;
    }*/

