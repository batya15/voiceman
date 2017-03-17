using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Voiceman {
    public class Fish : MonoBehaviour {

        bool move;   
        Trash trash;
        Vector3 startPos;

        void Awake() {
            trash = GlobalCacheFinder.FindObjectOfType<Trash>();
        }

        public void Init() {
            startPos = transform.position;
            move = true;
        }               

        void OnTriggerEnter2D(Collider2D other) {
            if (other.tag.Equals("character")) {
                move = false;
                other.GetComponent<Character>().Death();
                trash.UtilFish(this);
            }
            if (other.tag.Equals("visibility")) {
                move = false;
                trash.UtilFish(this);
            }
        }

        void Update() {
            if (move) {
                transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time) * 5.0f , 0);
            }
        }

    }
}

