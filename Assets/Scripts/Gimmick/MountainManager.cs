using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainManager : MonoBehaviour
{
    public int[] mountainLengthNum;

    public GameObject[] mountainPrefabs;

    public int prefabNum;

    public GameObject mountain;

    public GameObject goalPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 1; i < mountainLengthNum.Length; i++)
        {
            mountainLengthNum[i] = Random.Range(0, mountainPrefabs.Length);
        }

        for (int i = 0; i < mountainLengthNum.Length - 1; i++)
        {
            mountain = Instantiate(mountainPrefabs[mountainLengthNum[i]]);
            mountain.transform.position = new Vector3(1920 * i, -1156, -1547);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
