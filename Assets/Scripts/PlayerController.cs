using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float moveableRange = 5.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Imput.GetAxisRaw(
            "Horizontal") * speed * Time.delaTime, 0, 0);
        transform.position = new Vector2(Mathf.Clamp(
            transform.position.x, -moveableRange, moveableRange),
            transform.posotion.y);
    }
}
