using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyEndTImer : MonoBehaviour
{
    public GameObject mainText;

    public AudioClip sound1;
    AudioSource audioSource;

    public GameObject Chicken1;
    public GameObject Chicken2;
    public GameObject Chicken3;

    int killCount;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("ShowText",3f);
        killCount = PuzzleGameManager.Death_count;
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
        if(killCount<=3)
        {
            Chicken1.SetActive(true);
        }else if(killCount<=6)
        {
            Chicken2.SetActive(true);
        }else
        {
            Chicken3.SetActive(true);
        }
    }
}
