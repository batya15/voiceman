using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    public class FatalObject : MonoBehaviour {
                                        
        void OnTriggerEnter2D(Collider2D other) {
            if (other.tag.Equals("character")) {
                other.GetComponent<Character>().Death();
            }
        }

    }
}
