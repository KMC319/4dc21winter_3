using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Puzzle {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Liquid : MonoBehaviour {
        [SerializeField] private float lifeTime;
        private Rigidbody2D rigid;
        public Rigidbody2D Rigid => rigid ? rigid : rigid = GetComponent<Rigidbody2D>();
        private CancellationTokenSource cts;
        protected readonly Subject<Vector3> onAnnihilation = new Subject<Vector3>();
        public Subject<Vector3> OnAnnihilation => onAnnihilation;

        public readonly CompositeDisposable Disposable = new CompositeDisposable();
        

        private void OnEnable() {
            if (lifeTime > 0) DelayDisable().Forget();
        }

        private async UniTaskVoid DelayDisable() {
            cts = new CancellationTokenSource();
            await UniTask.Delay(TimeSpan.FromSeconds(lifeTime), cancellationToken: cts.Token);
            gameObject.SetActive(false);
        }

        private void OnDisable() {
            cts.Cancel();
            Disposable.Clear();
        }

        private void OnDestroy() {
            cts.Cancel();
            Disposable.Clear();
        }
    }
}
