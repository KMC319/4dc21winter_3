using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandManager : MonoBehaviour
{
    public int[] standLengthNum;

    public GameObject[] standPrefabs;

    public int prefabNum;

    public GameObject stand;

    public GameObject standPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(standPrefabs[0]);
        standLengthNum[0] = 0;
        Instantiate(standPrefabs[standLengthNum[0]]);
        for (int i = 1; i < standLengthNum.Length; i++)
        {
            standLengthNum[i] = Random.Range(0, standPrefabs.Length);
        }

        for (int i = 0; i < standLengthNum.Length - 1; i++)
        {
            stand = Instantiate(standPrefabs[standLengthNum[i]]);
            stand.transform.position = new Vector2(1920 * i+stand.transform.position.x, stand.transform.position.y);
        }
        stand = Instantiate(standPrefab);
        stand.transform.position = new Vector2(1920 * (standLengthNum.Length - 1), -89);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
