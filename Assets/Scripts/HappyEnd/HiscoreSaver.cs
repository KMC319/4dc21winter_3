using System;
using ProjectSystem;
using UnityEngine;

namespace HappyEnd {
    public class HiscoreSaver : MonoBehaviour{
        private void Start() {
            ScoreManager.Save();
        }
    }
}
