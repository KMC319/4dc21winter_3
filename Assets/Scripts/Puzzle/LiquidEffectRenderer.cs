using UnityEngine;
using UnityEngine.UI;

namespace Puzzle {
    public class LiquidEffectRenderer : MonoBehaviour {
        [SerializeField] private int iterations;
        [SerializeField] private float blurSpread;
        [SerializeField] private Shader blurShader;
        [SerializeField] private Material targetMaterial;
        [SerializeField] private RawImage output;
        private Material blurMaterial;
        private Material BlurMaterial => blurMaterial != null ? blurMaterial : blurMaterial = new Material(blurShader);

        private Camera myCamera;
        private RenderTexture destinationTexture;

        protected void Start() {
            // Disable if the shader can't run on the users graphics card
            if (!blurShader
                || !BlurMaterial.shader.isSupported
                || !targetMaterial.shader.isSupported) {
                enabled = false;
                return;
            }

            myCamera = GetComponent<Camera>();
            var cameraTexture = new RenderTexture(Screen.width, Screen.height, 24);
            myCamera.targetTexture = cameraTexture;
            destinationTexture = new RenderTexture(Screen.width, Screen.height, 24);
            InitOutput();
        }

        private void InitOutput() {
            output.texture = destinationTexture;
            output.color = Color.white;
        }

        private void OnPostRender() {
            if (output.texture == null) {
                InitOutput();
            }
            
            var source = myCamera.targetTexture;
            Graphics.Blit(source, destinationTexture, blurMaterial);
            var rtW = source.width / 4;
            var rtH = source.height / 4;
            var buffer = RenderTexture.GetTemporary(rtW, rtH, 0);
            var size = 1f;
            var offsets = new[] {new Vector2(-size, -size), new Vector2(-size, size), new Vector2(size, size), new Vector2(size, -size)};
            Graphics.BlitMultiTap(source, buffer, BlurMaterial, offsets);

            for (var i = 0; i < iterations; i++) {
                var buffer2 = RenderTexture.GetTemporary(rtW, rtH, 0);
                size = 0.5f * i * blurSpread;
                offsets = new[] {new Vector2(-size, -size), new Vector2(-size, size), new Vector2(size, size), new Vector2(size, -size)};
                Graphics.BlitMultiTap(buffer, buffer2, BlurMaterial, offsets);
                RenderTexture.ReleaseTemporary(buffer);
                buffer = buffer2;
            }

            Graphics.Blit(buffer, destinationTexture, targetMaterial);
            RenderTexture.ReleaseTemporary(buffer);
        }
    }
}
