using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ProjectSystem {
    public class FadeManager : MonoBehaviour {
        private float fadeAlpha;
        private bool isFading;
        private float fadeTime;
        private Rect size = new Rect(0, 0, Screen.width, Screen.height);

        public Color fadeColor = Color.black;

        public void OnGUI() {
            if (!isFading) return;
            size.width = Screen.width;
            size.height = Screen.height;
            fadeColor.a = fadeAlpha;
            GUI.color = fadeColor;
            GUI.DrawTexture(size, Texture2D.whiteTexture);
        }

        public async UniTask FadeOut(float interval, CancellationToken token = default) {
            isFading = true;
            fadeTime = 0f;
            while (fadeTime <= interval) {
                fadeAlpha = Mathf.Lerp(0f, 1f, fadeTime / interval);
                fadeTime += Time.deltaTime;
                await UniTask.Yield();
            }
        }

        public async UniTask FadeIn(float interval, CancellationToken token = default) {
            var time = 0f;
            while (time <= interval) {
                fadeAlpha = Mathf.Lerp(1f, 0f, time / interval);
                time += Time.deltaTime;
                await UniTask.Yield();
            }

            isFading = false;
        }
    }
}
