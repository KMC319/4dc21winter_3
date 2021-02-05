using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace ProjectSystem {
    public static class SceneController {
        public static bool IsSceneChanging { get; private set; }

        private static readonly FadeManager FadeManager;
        private static float fadeTime = 0.5f;
        
        private static readonly Subject<Unit> onChangeScene = new Subject<Unit>();
        public static IObservable<Unit> OnChangeScene => onChangeScene;
        
        public static SceneName CurrentScene { get; private set; } = (SceneName) SceneManager.GetActiveScene().buildIndex;

        public static async UniTaskVoid SceneMove(SceneName scene, float fadeOutLength = 0f, float fadeInLength = 0f) {
            if (IsSceneChanging) return;
            if (fadeOutLength <= 0) fadeOutLength = fadeTime;
            if (fadeInLength <= 0) fadeInLength = fadeTime;
            IsSceneChanging = true;
            switch (scene) {
                case SceneName.Title:
                case SceneName.Puzzle:
                case SceneName.Action:
                case SceneName.GameOver:
                    await FadeManager.FadeOut(fadeOutLength);
                    await SceneManager.LoadSceneAsync((int) scene);
                    CurrentScene = scene;
                    onChangeScene.OnNext(Unit.Default);
                    await FadeManager.FadeIn(fadeInLength);
                    break;
                case SceneName.GameClear:
                    await SceneManager.LoadSceneAsync((int) scene);
                    onChangeScene.OnNext(Unit.Default);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(scene), scene, null);
            }

            IsSceneChanging = false;
        }

        static SceneController() {
            FadeManager = new GameObject(nameof(FadeManager)).AddComponent<FadeManager>();
            Object.DontDestroyOnLoad(FadeManager.gameObject);
        }
    }

    public enum SceneName {
        Title,
        Puzzle,
        Action,
        GameClear,
        GameOver
    }
}
