using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Chiken : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("show_chicken", 5.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void show_chicken()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        
    }
}
