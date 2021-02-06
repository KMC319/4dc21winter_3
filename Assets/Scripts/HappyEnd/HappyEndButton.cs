using ProjectSystem;
using UnityEngine;

namespace HappyEnd {
    public class HappyEndButton : MonoBehaviour {
        public void Tomain() {
            Debug.Log("replay");
            SceneController.SceneMove(SceneName.Puzzle).Forget();
        }

        public void Totitle() {
            Debug.Log("titleへ");
            SceneController.SceneMove(SceneName.Title).Forget();
        }

        public void Toquit() {
            Debug.Log("end");
            Application.Quit();
        }
    }
}
