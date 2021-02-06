using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using ProjectSystem;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Action {
    public class ActionController : MonoBehaviour {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Animator deadPlayer;
        [SerializeField] private Vector3 spawnPoint;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private AudioSource bgm;
        private int chickenLife;
        public int yakitori;
        public int toripack;
        private Animator currentPlayer;

        private void Awake() {
            chickenLife = PuzzleGameManager.Chicken_count;
            yakitori = PuzzleGameManager.Yakitori_count;
            toripack = PuzzleGameManager.Toripack_count;
            Observable.Timer(TimeSpan.FromSeconds(deadPlayer.GetCurrentAnimatorStateInfo(0).length))
                .First()
                .Subscribe(_ => {
                    bgm.Play();
                    StartCoroutine(StartAnim());
                });
        }

        private IEnumerator StartAnim() {
            var p = Instantiate(playerController, (Vector2) mainCamera.transform.position + (Vector2) spawnPoint, Quaternion.identity);
            currentPlayer = p.GetComponent<Animator>();
            yield return new WaitForSeconds(1f);
            p.OnActive(this);
        }

        public void Dead(PlayerDeadType deadType) {
            chickenLife--;
            StartCoroutine(DeadAnim(deadType));
            if (chickenLife <= 0) {
                SceneController.SceneMove(SceneName.GameOver).Forget();
                return;
            }
        }

        private IEnumerator DeadAnim(PlayerDeadType deadType) {
            switch (deadType) {
                case PlayerDeadType.Hot:
                    currentPlayer.SetTrigger("hot");
                    break;
                case PlayerDeadType.Cold:
                    currentPlayer.SetTrigger("cold");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(deadType), deadType, null);
            }

            yield return new WaitForSeconds(1f);
            StartCoroutine(StartAnim());
        }
    }
}
