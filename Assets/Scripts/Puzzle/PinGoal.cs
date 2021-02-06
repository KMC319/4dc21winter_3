using System;
using System.Linq;
using ProjectSystem.Sound;
using UnityEngine;

namespace Puzzle {
    public class PinGoal : MonoBehaviour {
        [SerializeField] private GoalablePin[] pins;
        [SerializeField] private SePlayer sePlayer;
        private int count = 0;

        private void OnTriggerEnter2D(Collider2D other) {
            var pin = pins.Select((p,i) => new{pin = p, index = i})
                .FirstOrDefault(x => x.pin.gameObject == other.gameObject);
            if (pin != default) {
                pin.pin.Goal();
                if (pin.index != count) {
                    Fault(pin.index);
                }
                count++;
            }
        }

        private void Fault(int count) {
            sePlayer.PlayOneShot(sePlayer.SoundDatabase.Fault);
            switch (count) {
                case 0:
                case 1:
                case 2:
                    break;
                case 3:
                        break;
                default:
                    
                    break;
            }
        }
    }
}
