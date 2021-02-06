using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 startPlayerOffset;
    private Vector3 startCameraPos;
    [SerializeField]
    public float RATE = 0.12f;

    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        startPlayerOffset = player.transform.position;
        startCameraPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = (player.transform.position - startPlayerOffset) * RATE;
        this.transform.position = new Vector3(startCameraPos.x+v.x,startCameraPos.y,startCameraPos.z);
    }
}
