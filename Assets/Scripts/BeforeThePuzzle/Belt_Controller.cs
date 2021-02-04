using System.Collections;
using System.Collections.Generic;
using UnityEngine;


      public class Belt_Controller : MonoBehaviour
    {

    [SerializeField]
    private float moveSpeed = 100.0f;

    void OnCollisionStay2D(Collision2D other)
    {
        var body = other.gameObject.GetComponent<Rigidbody2D>();
        if (body != null)
        {
            other.transform.position = other.transform.position + new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
    }


}
    


    

