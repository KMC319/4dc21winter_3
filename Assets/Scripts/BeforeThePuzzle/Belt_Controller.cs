using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ProjectSystem;
using UnityEngine;


      public class Belt_Controller : MonoBehaviour
    {

    [SerializeField]
    private float moveSpeed = 100.0f;

    [SerializeField] private SpriteRenderer gear;
    [SerializeField] private float gearSpeed = -30f;
    private bool isActive = true;

    private void Update() {
        if(!isActive) return;
        var rota = gear.transform.eulerAngles;
        rota.z += gearSpeed * Time.deltaTime;
        gear.transform.eulerAngles = rota;
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if(!isActive) return;
        var body = other.gameObject.GetComponent<Rigidbody2D>();
        if (body != null)
        {
            other.transform.position = other.transform.position + new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
    }

    //ベルトコンベアのアクティブを切り替えて、5秒後にシーンチェンジ
    public async UniTaskVoid Break() {
        isActive = false;
        await UniTask.Delay(TimeSpan.FromSeconds(5f), cancellationToken: gameObject.GetCancellationTokenOnDestroy());
        SceneController.SceneMove(SceneName.Action).Forget();
    }
    
}
    


    

