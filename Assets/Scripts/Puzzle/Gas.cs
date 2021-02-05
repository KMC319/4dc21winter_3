using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Puzzle {
    public class Gas : MonoBehaviour {
        private ParticleSystem particleSystem;
        private ParticleSystem.Particle[] particles;
        [SerializeField] private LiquidSpawner waterSpawner;
        private bool isDissolve;

        private void Awake() {
            particleSystem = GetComponent<ParticleSystem>();
            particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
            waterSpawner.OnSpawnLiquid
                .Subscribe(w => particleSystem.trigger.AddCollider(w.GetComponent<Collider2D>()))
                .AddTo(waterSpawner);
        }

        private void OnParticleTrigger() {
            var p = new List<ParticleSystem.Particle>();
            var num = particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, p);
            p = p.Where(x => x.remainingLifetime > 0.1f)
                .Select(x => {
                    x.remainingLifetime = 0.1f;
                    x.velocity = Vector3.zero;
                    return x;
                })
                .ToList();

            particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, p);
        }

        private void DissolveAll() {
            var num = particleSystem.GetParticles(particles);
            particles = particles
                .Select(x => {
                    if (x.remainingLifetime > 0.1f) x.remainingLifetime = Random.Range(1f, 3f);
                    return x;
                })
                .ToArray();
            particleSystem.SetParticles(particles, num);
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (!isDissolve && other.gameObject.TryGetComponent<Water>(out _)) {
                isDissolve = true;
                DissolveAll();
            }
        }
    }
}
