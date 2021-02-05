using System;
using UnityEngine;

namespace Puzzle {
    public class Lava : Liquid {
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent<Birds_controller>(out var bird)) {
                bird.Dead();
            }
        }
    }
}
