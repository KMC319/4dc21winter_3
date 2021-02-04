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

    public float timer = 15.0f;

    public GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Blink");
        Destroy(this.gameObject, timer);
        Camera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime; time += Time.deltaTime;
        this.gameObject.transform.position= new Vector2(Camera.transform.position.x -787, this.gameObject.transform.position.y);
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
        //生成した敵の座標を決定する
        knife.transform.position = new Vector2(this.gameObject.transform.position.x-500, this.gameObject.transform.position.y);
    }
}
