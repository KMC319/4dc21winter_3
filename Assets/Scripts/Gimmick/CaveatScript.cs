using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://teratail.com/questions/137923

public class CaveatScript : MonoBehaviour
{
    public float blinInterval=0.1f;
    public float delayTime;
    private float time = 0f;
    public bool danger;
    public GameObject knifePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Blink");

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; time += Time.deltaTime;
    }
    IEnumerator Blink()
    {
        while (true)
        {
            var renderComponent = GetComponent<Renderer>();
            if (delayTime<time)
            {
                renderComponent.enabled = false;
                Shot();
                yield break;

            }
            
            renderComponent.enabled = !renderComponent.enabled;
            yield return new WaitForSeconds(blinInterval);
        }
    }
    void Shot()
    {
        //knifeをインスタンス化する(生成する)
        GameObject knife = Instantiate(knifePrefab);
        //生成した敵の座標を決定する(現状X=0,Y=10,Z=20の位置に出力)
        knife.transform.position = new Vector2(-1165, -24);
    }
}
