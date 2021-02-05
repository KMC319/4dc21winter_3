using System;
using UnityEngine;

namespace Puzzle {
    public class Water : Liquid {
        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.TryGetComponent<Lava>(out var lava)) {
                onAnnihilation.OnNext(transform.position);
                gameObject.SetActive(false);
                lava.gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent<Birds_controller>(out var bird)) {
                bird.Dead();
            }
        }
    }
}
