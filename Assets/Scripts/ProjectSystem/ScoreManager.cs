using Action;
using UnityEngine;

namespace ProjectSystem {
    public static class ScoreManager {
        public static float HiScore { get; private set; }
        public static float PastScore { get; private set; } = 0;
        public static float CurrentScore => PuzzleGameManager.Chicken_count * 59472 - Timer.GameTime * 5000;
        private static string key = "hiScore";
        
        public static void Save() {
            PastScore = CurrentScore;
            if (HiScore <= CurrentScore) {
                HiScore = CurrentScore;
                PlayerPrefs.SetFloat(key, CurrentScore);
            }
        }

        static ScoreManager() {
            HiScore = PlayerPrefs.GetFloat(key, 0);
        }
    }
}
