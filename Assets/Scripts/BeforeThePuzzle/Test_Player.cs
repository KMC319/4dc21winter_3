using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Player : MonoBehaviour
{
    float speed = 300;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 800)
            {
                transform.position = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (-800 < transform.position.x)
            {
                transform.position = transform.position - new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
    }
}


