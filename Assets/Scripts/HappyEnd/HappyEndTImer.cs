using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyEndTImer : MonoBehaviour
{
    public GameObject mainText;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ShowText",3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowText()
    {
        mainText.SetActive(true);
    }
}
