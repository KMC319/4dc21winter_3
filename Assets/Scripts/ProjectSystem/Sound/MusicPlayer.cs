using System;
using UniRx;
using UnityEngine;

namespace ProjectSystem.Sound {
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour {
        private AudioSource source;
        private readonly Subject<Unit> endMusic = new Subject<Unit>();
        public IObservable<Unit> OnEndMusic => endMusic;
        private bool isPausing;

        private void Awake() {
            source = GetComponent<AudioSource>();
        }

        public void SetMusic(AudioClip clip) {
            source.clip = clip;
        }

        public void Play(bool canLoop = true) {
            source.loop = canLoop;
            source.Play();
            Observable.EveryUpdate()
                .Where(_ => !isPausing)
                .First(_ => !source.isPlaying)
                .Subscribe(_ => endMusic.OnNext(Unit.Default))
                .AddTo(source);
        }

        public void Pause() {
            isPausing = true;
            source.Pause();
        }

        public void Resume() {
            source.UnPause();
            isPausing = false;
        }
    }
}
