using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    namespace BeeMob {
        public class BeeOnTrigerSide : MonoBehaviour {

            Bee bee;

            void Awake() {
                bee = GetComponentInParent<Bee>();
            }
                      
            void OnTriggerExit2D(Collider2D other) {
                if (other.tag.Equals("ground")) {
                    bee.ToogleDirection();
                }                                       
            }

        }

    }

}
