using UnityEngine;

namespace ProjectSystem.Sound {
    [CreateAssetMenu(menuName = "Database/SoundDatabase")]
    public class SoundDatabase : ScriptableObject {
        //AudioClipを登録する
        [SerializeField] private AudioClip chickenDead;
        [SerializeField] private AudioClip fault;
        [SerializeField] private AudioClip chicken;
        public AudioClip ChickenDead => chickenDead;
        public AudioClip Fault => fault;
        public AudioClip Chicken => chicken;
    }
}
