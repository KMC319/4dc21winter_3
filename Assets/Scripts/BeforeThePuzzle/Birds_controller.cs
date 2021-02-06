using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ProjectSystem.Sound;
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
        PuzzleGameManager.Chicken_count--;
        PuzzleGameManager.Death_count++;
        switch (deadType) {
            case PlayerDeadType.Hot:
                PuzzleGameManager.Yakitori_count++;
                break;
            case PlayerDeadType.Cold:
                PuzzleGameManager.Toripack_count++;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(deadType), deadType, null);
        }
    }

    private async UniTaskVoid DeadAnim() {
        var se = GetComponent<SePlayer>();
        se.PlayOneShot(se.SoundDatabase.ChickenDead);
        GetComponent<SpriteRenderer>().sprite = deadBird;
        await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: gameObject.GetCancellationTokenOnDestroy());
        Destroy(gameObject);
    }
}

public enum PlayerDeadType {
    Hot, Cold
}
