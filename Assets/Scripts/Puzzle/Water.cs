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
    }
}
