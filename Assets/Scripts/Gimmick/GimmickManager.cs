using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : MonoBehaviour
{
    // �����I�ɂ̓��e�I�̊Ǘ����s��
    // �i�C�t�ƌx���̊Ǘ���KnifeManager
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
            //meteor���C���X�^���X������(��������)
            GameObject meteor = Instantiate(meteorPrefab);
            //���������G�̍��W�����肷��(����X=0,Y=10,Z=20�̈ʒu�ɏo��)
            meteor.transform.position = new Vector2(Camera.transform.position.x + meteorPosition[meteorNum].x, meteorPosition[meteorNum].y);
            //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
            time = 0f;
            interval = Random.Range(intervalMin, intervalMax);
        }
    }
}
