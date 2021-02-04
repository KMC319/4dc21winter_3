using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds_controller : MonoBehaviour
{

    private void Update()
    {
        if(transform.position.y<-800)
        {
            Dead();
        }
    }
    public void Dead()
    {
        Destroy(this.gameObject);
        PuzzleGameManager gameManager = GameObject.Find("PuzzleGameManager").GetComponent<PuzzleGameManager>();
        gameManager.Chicken_count--;
    }
}
