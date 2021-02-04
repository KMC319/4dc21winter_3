using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds_controller : MonoBehaviour
{
    public float speed;
    private bool down_operate = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (down_operate == true)
        {
            transform.position = transform.position - new Vector3(0, speed, 0) * Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "belt")
        {
           transform.position = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
            down_operate = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "belt")
        {
            transform.position = transform.position - new Vector3(0, speed, 0) * Time.deltaTime;
        }
    }
}
