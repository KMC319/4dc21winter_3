using ProjectSystem;
using UnityEngine;

namespace Title {
    public class GameStart : MonoBehaviour{
        public void StartGame() {
            SceneController.SceneMove(SceneName.Puzzle).Forget();
        }
    }
}
