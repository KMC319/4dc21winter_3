using System.Collections;
using System.Collections.Generic;
using ProjectSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Debug.Log("aaaa");
            SceneController.SceneMove(SceneName.GameClear).Forget();
        }
    }
}
