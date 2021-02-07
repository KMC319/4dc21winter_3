using Action;
using UnityEngine;

namespace ProjectSystem {
    public static class ScoreManager {
        public static int HiScore { get; private set; }
        public static int PastScore { get; private set; } = 0;
        public static int CurrentScore => (int) (PuzzleGameManager.Chicken_count * 59472 - Timer.GameTime * 5000);
        private static string key = "hiScore";
        
        public static void Save() {
            PastScore = CurrentScore;
            if (HiScore <= CurrentScore) {
                HiScore = CurrentScore;
                PlayerPrefs.SetFloat(key, CurrentScore);
            }
        }

        static ScoreManager() {
            HiScore = PlayerPrefs.GetInt(key, 0);
        }
    }
}
