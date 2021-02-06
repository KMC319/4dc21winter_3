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
            StartCoroutine(ActiveWithFade(Chicken1.GetComponent<SpriteRenderer>(), 0.72f));
        }else if(killCount<=6)
        {
            StartCoroutine(ActiveWithFade(Chicken2.GetComponent<SpriteRenderer>(), 0.72f));
        }else
        {
            StartCoroutine(ActiveWithFade(Chicken3.GetComponent<SpriteRenderer>(), 1));
        }
    }

    IEnumerator ActiveWithFade(SpriteRenderer sprite, float alpha ,float time = 2f) {
        sprite.gameObject.SetActive(true);
        var startTime = time;
        while (time > 0) {
            var c = sprite.color;
            c.a = (1 - time / startTime) * alpha;
            sprite.color = c;
            time -= Time.deltaTime;
            yield return null;
        }
    }
    
}
