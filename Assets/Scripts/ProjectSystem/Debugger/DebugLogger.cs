namespace ProjectSystem.Debugger {
    public static class DebugLogger {
        public static void Log(object message) {
#if UNITY_EDITOR
            UnityEngine.Debug.Log(message);
#endif
        }

        public static void LogError(object message) {
#if UNITY_EDITOR
            UnityEngine.Debug.unityLogger.LogError("Error", message);
#endif
        }

        public static void LogWarning(object message) {
#if UNITY_EDITOR
            UnityEngine.Debug.unityLogger.LogWarning("Error", message);
#endif
        }
    }
}
