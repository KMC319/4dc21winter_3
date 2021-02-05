using UnityEngine;

namespace Puzzle {
    public class Rock : MonoBehaviour {
        private bool once;

        private void OnCollisionEnter2D(Collision2D other) {
            if (!once && other.gameObject.TryGetComponent<Belt_Controller>(out var b)) {
                once = true;
                b.Break().Forget();
            }
            if (other.gameObject.TryGetComponent<Birds_controller>(out var bird)) {
                bird.Dead(PlayerDeadType.Cold);
            }
        }
    }
}
