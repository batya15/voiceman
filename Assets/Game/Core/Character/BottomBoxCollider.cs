using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    public class BottomBoxCollider : MonoBehaviour {

        Character character;

        void Awake() {
            character = transform.parent.GetComponent<Character>();
        }

        void OnTriggerExit2D() {
            character.OnChangeBottomCollider(true);
        }


        void OnTriggerEnter2D() {
            character.OnChangeBottomCollider(false);
        }

    }
}
