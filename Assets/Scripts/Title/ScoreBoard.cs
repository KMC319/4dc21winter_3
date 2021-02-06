using System;
using ProjectSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Title {
    public class ScoreBoard : MonoBehaviour {
        [SerializeField] private Text hiText;
        [SerializeField] private Text pastText;

        private void Start() {
            hiText.text = $"ハイスコア：　{ScoreManager.HiScore}";
            pastText.text = $"前回のスコア：　{ScoreManager.PastScore}";
        }
    }
}
