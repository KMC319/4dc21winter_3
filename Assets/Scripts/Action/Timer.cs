using UnityEngine;
using UnityEngine.UI;

namespace Action {
    public class Timer : MonoBehaviour {
        public static float GameTime;
        [SerializeField] private Text display;

        private void Start() {
            GameTime = 0;
        }

        private void Update() {
            GameTime += Time.deltaTime;
            Display();
        }

        private void Display() {
            var min = (int) (GameTime / 60);
            var sec = GameTime % 60;

            display.text = $"{min:00}:{sec:00.00}";
        }
    }
}
