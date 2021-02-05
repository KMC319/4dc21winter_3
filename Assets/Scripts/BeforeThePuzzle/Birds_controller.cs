using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Birds_controller : MonoBehaviour {
    private bool isDead;
    [SerializeField] private Sprite deadBird;
    private void Update()
    {
        if(transform.position.y<-800)
        {
            Dead();
        }
    }
    public void Dead(PlayerDeadType deadType = PlayerDeadType.Hot) 
    {
        if(isDead) return;
        isDead = true;
        DeadAnim().Forget();
        PuzzleGameManager gameManager = GameObject.Find("PuzzleGameManager").GetComponent<PuzzleGameManager>();
        switch (deadType) {
            case PlayerDeadType.Hot:
                gameManager.Yakitori_count++;
                break;
            case PlayerDeadType.Cold:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(deadType), deadType, null);
        }
        gameManager.Chicken_count--;
    }

    private async UniTaskVoid DeadAnim() {
        GetComponent<SpriteRenderer>().sprite = deadBird;
        await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: gameObject.GetCancellationTokenOnDestroy());
        Destroy(gameObject);
    }
}

public enum PlayerDeadType {
    Hot, Cold
}
