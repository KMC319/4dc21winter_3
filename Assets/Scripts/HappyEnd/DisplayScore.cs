using System;
using ProjectSystem;
using UnityEngine;
using UnityEngine.UI;

namespace HappyEnd {
    [RequireComponent(typeof(Text))]
    public class DisplayScore  : MonoBehaviour{
        private void Start() {
            GetComponent<Text>().text = $"スコア：　{ScoreManager.CurrentScore}";
        }
    }
}
