using ProjectSystem;
using ProjectSystem.Sound;
using UnityEngine;

namespace Title {
    public class GameStart : MonoBehaviour {
        private bool once;
        public void StartGame() {
            if(once) return;
            once = true;
            var se = GetComponent<SePlayer>();
            se.PlayOneShot(se.SoundDatabase.Chicken);
            SceneController.SceneMove(SceneName.Puzzle, 1f, 1f).Forget();
        }
    }
}
