using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    // https://xr-hub.com/archives/16386

    public float interval;
    public float intervalMin;
    public float intervalMax;
    public GameObject meteorPrefab;
    private float time = 0f;
    public Vector2[] meteorPosition;
    public int meteorNum;

    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(intervalMin, intervalMax);
    }

    // Update is called once per frame
    void Update()
    {
        meteorNum = Random.RandomRange(0, meteorPosition.Length);
        time += Time.deltaTime;
        if (time > interval)
        {
            //meteor���C���X�^���X������(��������)
            GameObject meteor = Instantiate(meteorPrefab);
            //���������G�̍��W�����肷��(����X=0,Y=10,Z=20�̈ʒu�ɏo��)
            meteor.transform.position = meteorPosition[meteorNum];
            //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
            time = 0f;
            interval = Random.Range(3f, 10f);
        }
    }
}
