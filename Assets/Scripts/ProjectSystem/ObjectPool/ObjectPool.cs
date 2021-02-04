using System.Collections.Generic;
using ProjectSystem.Debugger;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProjectSystem.ObjectPool {
    /// <summary>
    /// オブジェクトプール
    /// 消すとき何かさせたいならOnDisableで
    /// </summary>
    public class ObjectPool<T> where T : Component {
        /// <summary>
        /// 登録オブジェクトをキーに
        /// プール済み複製オブジェクトのキューを返す
        /// </summary>
        private readonly Dictionary<int, Queue<T>> pooledObjects = new Dictionary<int, Queue<T>>();

        /// <summary>
        /// 複製オブジェクトをキーに
        /// 登録オブジェクトのIDを返す
        /// </summary>
        private readonly Dictionary<int, int> poolDatabase = new Dictionary<int, int>();

        private readonly Transform parent;
        public bool IsPooled(T instance) => pooledObjects.ContainsKey(instance.GetInstanceID());

        public T GetObject(T instance) {
            var instanceTransform = instance.transform;
            var obj = Rent(instance);
            var objTransform = obj.transform;
            objTransform.position = instanceTransform.position;
            objTransform.rotation = instanceTransform.rotation;
            return obj;
        }

        public T GetObject(T instance, Vector3 position) {
            var instanceTransform = instance.transform;
            var obj = Rent(instance);
            var objTransform = obj.transform;
            objTransform.position = position;
            objTransform.rotation = instanceTransform.rotation;
            return obj;
        }

        public T GetObject(T instance, Vector3 position, Quaternion rotation) {
            var obj = Rent(instance);
            var objTransform = obj.transform;
            objTransform.position = position;
            objTransform.rotation = rotation;
            return obj;
        }

        public void Preload(T instance, int num) {
            var key = instance.GetInstanceID();
            if (!pooledObjects.TryGetValue(key, out var pool)) {
                pool = ForceRegisterInstance(key);
            }

            for (var i = 0; i < num; i++) {
                CreateObject(instance, key, pool);
            }
        }

        public void ReturnObject(T instance) {
            if (!poolDatabase.TryGetValue(instance.GetInstanceID(), out var key)) {
                DebugLogger.LogWarning($"{instance} is not pooled object!");
                Object.Destroy(instance);
                return;
            }

            if (!pooledObjects.TryGetValue(key, out var pool)) {
                DebugLogger.LogWarning("Pool is broken! New pool is created automatically.");
                pool = ForceRegisterInstance(key);
            }

            pool.Enqueue(instance);
            instance.gameObject.SetActive(false);
        }

        public ObjectPool(Transform parent) {
            this.parent = parent;
        }

        public ObjectPool(T poolObj, Transform parent) {
            this.parent = parent;
            RegisterInstance(poolObj);
        }

        public ObjectPool(IEnumerable<T> poolList, Transform parent) {
            this.parent = parent;
            foreach (var poolData in poolList) {
                RegisterInstance(poolData);
            }
        }

        private Queue<T> RegisterInstance(T instance) {
            var key = instance.GetInstanceID();
            if (pooledObjects.TryGetValue(key, out var pool)) {
                DebugLogger.LogWarning($"{instance} is already pooled!");
                return pool;
            }

            return ForceRegisterInstance(key);
        }

        private Queue<T> ForceRegisterInstance(int key) {
            var pool = new Queue<T>();
            pooledObjects.Add(key, pool);
            return pool;
        }

        private T Rent(T instance) {
            var key = instance.GetInstanceID();
            if (!pooledObjects.TryGetValue(key, out var pool)) {
                DebugLogger.LogWarning("Pooled new object!");
                pool = ForceRegisterInstance(key);
            }

            if (pool.Count > 0) {
                var obj = pool.Dequeue();
                obj.gameObject.SetActive(true);
                return obj;
            } else {
                DebugLogger.LogWarning("Created new object!");
                var obj = CreateObject(instance, key);
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        private T CreateObject(T instance, int key, Queue<T> pool = null) {
            var obj = Object.Instantiate(instance, new Vector3(), new Quaternion(), parent);
            poolDatabase.Add(obj.GetInstanceID(), key);
            obj.gameObject.SetActive(false);
            pool?.Enqueue(obj);
            return obj;
        }
    }
}
