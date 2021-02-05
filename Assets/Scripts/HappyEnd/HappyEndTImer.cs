using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyEndTImer : MonoBehaviour
{
    public GameObject mainText;

    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("ShowText",3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowText()
    {
        audioSource.Play();
        audioSource.loop = true;
        mainText.SetActive(true);
    }
}
