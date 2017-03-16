using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    public class DownBoxCollider : MonoBehaviour {

        Character character;

        void Awake() {
            character = transform.parent.GetComponent<Character>();
        }

        void OnTriggerExit2D() {
            character.saveLastPosition();
        }

    }
}
