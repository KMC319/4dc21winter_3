using System.Collections;
using UnityEngine;

namespace Puzzle {
    public class GoalablePin : MonoBehaviour {
        public void Goal() {
            foreach (var x in GetComponents<Collider2D>()) {
                x.enabled = false;
            }

            StartCoroutine(Disable());
        }

        private IEnumerator Disable() {
            var sprite = GetComponent<SpriteRenderer>();
            var time = 1f;
            while (time > 0) {
                var c = sprite.color;
                c.a = time;
                sprite.color = c;
                yield return null;
                time -= Time.deltaTime;
            }
            Destroy(gameObject);
        }
    }
}
