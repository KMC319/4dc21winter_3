using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class ToripackText : MonoBehaviour {
        private Text text;

        private void Start() {
            text = GetComponent<Text>();
            Display();
        }

        private void Update() {
            Display();
        }

        private void Display() {
            text.text = $"x{PuzzleGameManager.Toripack_count}";
        } }
}
