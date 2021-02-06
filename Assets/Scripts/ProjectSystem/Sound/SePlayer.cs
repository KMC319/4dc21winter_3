using UnityEngine;

namespace ProjectSystem.Sound {
    /// <summary>
    /// 汎用SE再生クラス
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SePlayer : MonoBehaviour {
        public SoundDatabase SoundDatabase;
        private AudioSource audioSource;

        private void Awake() {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShot(AudioClip clip) {
            audioSource.PlayOneShot(clip);
        }
        
        public void PlayOneShot(AudioClip clip, float volumeScale) {
            audioSource.PlayOneShot(clip, volumeScale);
        }
    }
}
