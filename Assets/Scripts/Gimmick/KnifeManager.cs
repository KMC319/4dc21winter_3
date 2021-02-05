using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeManager : MonoBehaviour
{
    public float interval;
    public float intervalMin;
    public float intervalMax;
    public GameObject CaveatPrefab;
    private float time = 0f;
    public Vector2[] CaveatPosition;
    public int CaveatNum;

    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CaveatNum = Random.RandomRange(0, CaveatPosition.Length);
        time += Time.deltaTime;
        if (time > interval)
        {
            //meteorをインスタンス化する(生成する)
            GameObject caveat = Instantiate(CaveatPrefab);
            //生成した敵の座標を決定する
            caveat.transform.position = new Vector2(Camera.transform.position.x+ CaveatPosition[CaveatNum].x, CaveatPosition[CaveatNum].y);
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
            interval = Random.Range(intervalMin, intervalMax);
        }
    }
}
