using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Voiceman {
    public class Coin : MonoBehaviour {

        Trash trash;

        void Awake() {
            trash = GlobalCacheFinder.FindObjectOfType<Trash>();
        }

        void OnTriggerEnter2D(Collider2D other) {
            if (other.tag.Equals("character")) {
                Prefs.UserPrefs.coins++;
                Broadcaster.SendEvent("PlayOneShot", "coin");
                trash.UtilCoins(this);
            }

            if (other.tag.Equals("visibility")) {
                trash.UtilCoins(this);
            }
        }
    }
}
