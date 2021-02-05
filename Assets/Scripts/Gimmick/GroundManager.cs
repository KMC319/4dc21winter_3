using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public int[] groundLengthNum;

    public GameObject[] groundPrefabs;

    public int prefabNum;

    public GameObject ground;

    public GameObject goalPrefab;

    void Start()
    {
        Instantiate(groundPrefabs[0]);
        groundLengthNum[0] = 0;
        Instantiate(groundPrefabs[groundLengthNum[0]]);
        for(int i=1;i<groundLengthNum.Length;i++)
        {
            groundLengthNum[i]= Random.Range(0, groundPrefabs.Length);
        }
        
        for(int i=0; i < groundLengthNum.Length-1; i++)
        {
            ground= Instantiate(groundPrefabs[groundLengthNum[i]]);
            ground.transform.position = new Vector2(1920*i, -89);
        }
        ground = Instantiate(goalPrefab);
        ground.transform.position = new Vector2(1920 * (groundLengthNum.Length-1), -89);
    }


    void Update()
    {
        
        
    }
}
