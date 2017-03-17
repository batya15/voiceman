using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Voiceman {
    namespace BeeMob {
        public class Bee : MonoBehaviour {

            enum SIDE {
                LEFT, RIGHT         
            }

            SIDE direction;  
            bool move;

            Trash trash;

            void Awake() {
                trash = GlobalCacheFinder.FindObjectOfType<Trash>();
            }

            public void Init() {
                direction = SIDE.LEFT;
                move = true;
            }               

            public void ToogleDirection() {
                direction = direction == SIDE.LEFT ? SIDE.RIGHT : SIDE.LEFT;    
            }

            void OnTriggerEnter2D(Collider2D other) {
                if (other.tag.Equals("character")) {
                    move = false;
                    other.GetComponent<Character>().Death();
                    trash.UtilBee(this);
                }
                if (other.tag.Equals("visibility")) {
                    move = false;
                    trash.UtilBee(this);
                }
            }

            void Update() {
                if (move) {
                    int d = direction == SIDE.LEFT ? -1 : 1;
                    transform.position = transform.position + new Vector3(Time.deltaTime * d * 2, 0, 0);
                }
            }

        }
    }
}

