using System;
using UniRx;
using Unity.Mathematics;
using UnityEngine;

namespace Puzzle {
    public class RockSpawner : MonoBehaviour {
        [SerializeField] private int border;
        [SerializeField] private SpriteRenderer rock;
        private readonly Subject<Unit> onSpawnRock = new Subject<Unit>();
        public IObservable<Unit> OnSpawnRock => onSpawnRock;
        
        private int counter;
        private Vector3 spawnPoint = Vector3.zero;
        
        public void CreateRock(Vector3 position) {
            spawnPoint += position;
            counter++;
            if (counter >= border) {
                Spawn();    
            }
        }

        private void Spawn() {
            Instantiate(rock, spawnPoint/counter, Quaternion.identity);
            onSpawnRock.OnNext(Unit.Default);
            counter = 0;
            spawnPoint = Vector3.zero;
        }
    }
}
