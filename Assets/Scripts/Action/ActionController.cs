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
        private (PlayerController controller, SpriteRenderer anim) currentPlayer;

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
            currentPlayer = (p, p.GetComponent<SpriteRenderer>());
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
            StartCoroutine(p.Muteki(1f));
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
                    break;
                case PlayerDeadType.Cold:
                    toripack++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(deadType), deadType, null);
            }

            yield return new WaitForSeconds(0.5f);
            var time = 0.5f;
            while (time > 0f) {
                var c = currentPlayer.anim.color;
                c.a = time * 2;
                currentPlayer.anim.color = c;
                time -= Time.deltaTime;
            }
            Destroy(currentPlayer.anim.gameObject);
            StartCoroutine(StartAnim());
        }
    }
}
