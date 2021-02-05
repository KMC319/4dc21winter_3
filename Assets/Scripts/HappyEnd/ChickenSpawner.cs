using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    public GameObject ChickenPrefab;
    private GameObject Chicken;

    public float blinInterval = 0.1f;

    public int maxChicken;
    public int currentChiken;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DelaySpawn");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    IEnumerator DelaySpawn()
    {
        while (true&maxChicken>=currentChiken)
        {
            Chicken = Instantiate(ChickenPrefab);
            Chicken.transform.position = gameObject.transform.position;
            currentChiken++;
            yield return new WaitForSeconds(blinInterval);
        }
    }

}
