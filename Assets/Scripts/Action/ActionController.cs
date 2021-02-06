using System;
using System.Collections;
using ProjectSystem;
using UniRx;
using UnityEngine;

namespace Action {
    public class ActionController : MonoBehaviour {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private Animator deadPlayer;
        [SerializeField] private Vector3 spawnPoint;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private AudioSource bgm;
        
        private int chickenLife { get => PuzzleGameManager.Chicken_count; set => PuzzleGameManager.Chicken_count = value; }
        public int yakitori{ get => PuzzleGameManager.Yakitori_count; set => PuzzleGameManager.Yakitori_count = value; }
        public int toripack{ get => PuzzleGameManager.Toripack_count; set => PuzzleGameManager.Toripack_count = value; }
        private (PlayerController controller, Animator anim) currentPlayer;

        private bool isFirst;
        private readonly Subject<Unit> onGameStart = new Subject<Unit>();
        public IObservable<Unit> OnGameStart => onGameStart;
        

        private void Awake() {
            Observable.Timer(TimeSpan.FromSeconds(deadPlayer.GetCurrentAnimatorStateInfo(0).length))
                .First()
                .Subscribe(_ => {
                    bgm.Play();
                    StartCoroutine(StartAnim());
                });
        }

        private void Update() {
            if (currentPlayer.controller != null && currentPlayer.controller.IsActive) {
                transform.position = currentPlayer.controller.transform.position;
            }
        }

        private IEnumerator StartAnim() {
            var p = Instantiate(playerController, (Vector2) mainCamera.transform.position + (Vector2) spawnPoint, Quaternion.identity);
            currentPlayer = (p, p.GetComponent<Animator>());
            while (currentPlayer.controller.transform.position.x < transform.position.x) {
                var pos = currentPlayer.controller.transform.position;
                pos.x += currentPlayer.controller.speed * Time.deltaTime;
                currentPlayer.controller.transform.position = pos;
                yield return null;
            }

            if (!isFirst) {
                isFirst = true;
                onGameStart.OnNext(Unit.Default);
            }
            p.OnActive(this);
        }

        public void Dead(PlayerDeadType deadType) {
            chickenLife--;
            StartCoroutine(DeadAnim(deadType));
            if (chickenLife <= 0) {
                SceneController.SceneMove(SceneName.GameOver).Forget();
            }
        }

        private IEnumerator DeadAnim(PlayerDeadType deadType) {
            switch (deadType) {
                case PlayerDeadType.Hot:
                    yakitori++;
                    toripack++;
                    currentPlayer.anim.SetTrigger("hot");
                    break;
                case PlayerDeadType.Cold:
                    currentPlayer.anim.SetTrigger("cold");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(deadType), deadType, null);
            }

            yield return new WaitForSeconds(1f);
            Destroy(currentPlayer.anim.gameObject);
            StartCoroutine(StartAnim());
        }
    }
}
