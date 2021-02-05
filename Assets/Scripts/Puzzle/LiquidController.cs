using System;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Puzzle {
    public class LiquidController : MonoBehaviour {
        [SerializeField] private LiquidSpawner waterSpawner;
        [SerializeField] private LiquidSpawner lavaSpawner;
        [SerializeField] private RockSpawner rockSpawner;
        private bool isEndlessWater;
        private void Start() {
            Observable.Interval(TimeSpan.FromSeconds(5))
                .Subscribe(_ => CreateLiquid())
                .AddTo(this);
        }

        private void CreateLiquid() {
            if (isEndlessWater) {
                waterSpawner.StartSpawn(50);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(isEndlessWater) return;
            if (other.GetComponentInParent<Water>() != null) {
                isEndlessWater = true;
            }
        }
    }
}
