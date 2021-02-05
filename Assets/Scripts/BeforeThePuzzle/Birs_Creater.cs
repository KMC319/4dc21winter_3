using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birs_Creater : MonoBehaviour
{
    public GameObject Birds;
    public float create_time;
    private float count;

    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(Birds, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (create_time < count) {
            Instantiate(Birds, transform.position, Quaternion.identity);
            count = 0;
        }
        
    }
  
}
