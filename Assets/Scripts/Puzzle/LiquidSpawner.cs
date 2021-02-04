using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ProjectSystem.ObjectPool;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Puzzle {
    public class LiquidSpawner : MonoBehaviour {
        private ObjectPool<Liquid> pool;
        [SerializeField] private Liquid originalLiquid;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private int size;
        [SerializeField] private float spawnRate;
        [SerializeField] private RockSpawner rockSpawner;
        private CancellationTokenSource cts = new CancellationTokenSource();
        private List<Liquid> activeLiquid = new List<Liquid>();

        private void Start() {
            pool = new ObjectPool<Liquid>(originalLiquid, spawnPoint);
            pool.Preload(originalLiquid, size);
            StartSpawn(100);
            rockSpawner.OnSpawnRock
                .Subscribe(_ => DestroyLiquid())
                .AddTo(gameObject);
        }

        public void StartSpawn(int count = 0) {
            EndlessSpawn(count).Forget();
        }

        public void StopSpawn() {
            cts.Cancel();
            cts = new CancellationTokenSource();
        }

        private void DestroyLiquid() {
            var temp = new List<Liquid>(activeLiquid);
            foreach (var liquid in temp) {
                liquid.gameObject.SetActive(false);
            }
        }

        private async UniTaskVoid EndlessSpawn(int count) {
            var endless = count <= 0;
            while (count > 0 || endless) {
                Spawn();
                count--;
                await UniTask.Delay(TimeSpan.FromSeconds(spawnRate), cancellationToken: cts.Token);
            }
        }

        private void Spawn() {
            var obj = pool.GetObject(originalLiquid, spawnPoint.position, Quaternion.identity);
            obj.Rigid.velocity = Vector2.right * Random.Range(-10f, 10f);
            activeLiquid.Add(obj);
            obj.OnDisableAsObservable()
                .First()
                .Subscribe(_ => {
                    pool.ReturnObject(obj);
                    activeLiquid.Remove(obj);
                })
                .AddTo(obj);
            obj.OnAnnihilation
                .First()
                .Subscribe(pos => rockSpawner.CreateRock(pos))
                .AddTo(obj.Disposable);
        }

        private void OnDestroy() {
            cts.Cancel();
        }
    }
}
