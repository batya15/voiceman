using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    public class Trash : MonoBehaviour {

        [SerializeField]
        Transform grownd;
        [SerializeField]
        Transform coins;

        void Awake() {
            transform.position = new Vector3(-100000, 0, 0);
        }

        public GameObject GetGround() {
            if (grownd.childCount == 0) {
                return null;
            } else {
                return grownd.GetChild(0).gameObject;
            }
            
        }

        public void UtilGround(Ground g) {
            g.transform.SetParent(grownd);
            g.transform.localPosition = Vector3.zero;
        }

        public GameObject GetCoins() {
            if (coins.childCount == 0) {
                return null;
            } else {
                return coins.GetChild(0).gameObject;
            }

        }

        public void UtilCoins(Coin g) {
            g.transform.SetParent(coins);
            g.transform.localPosition = Vector3.zero;
        }


    }
}
