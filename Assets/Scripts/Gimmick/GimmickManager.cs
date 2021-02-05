using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    // 実質的にはメテオの管理を行う
    // ナイフと警告の管理はKnifeManager
    // https://xr-hub.com/archives/16386

    public float interval;
    public float intervalMin;
    public float intervalMax;
    public GameObject meteorPrefab;
    private float time = 0f;
    public Vector2[] meteorPosition;
    public int meteorNum;

    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        meteorNum = Random.RandomRange(0, meteorPosition.Length);
        time += Time.deltaTime;
        if (time > interval)
        {
            //meteorをインスタンス化する(生成する)
            GameObject meteor = Instantiate(meteorPrefab);
            //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
            meteor.transform.position = new Vector2(Camera.transform.position.x + meteorPosition[meteorNum].x, meteorPosition[meteorNum].y);
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
            interval = Random.Range(intervalMin, intervalMax);
        }
    }
}
