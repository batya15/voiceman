using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Voiceman {
    public class Trash : MonoBehaviour {

        [SerializeField]
        Transform grownd;
        [SerializeField]
        Transform coins;
        [SerializeField]
        Transform bees;
        [SerializeField]
        Transform fishs;

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


        public GameObject GetBee() {
            if (bees.childCount == 0) {
                return null;
            } else {
                return bees.GetChild(0).gameObject;
            }

        }

        public void UtilBee(BeeMob.Bee g) {
            g.transform.SetParent(bees);
            g.transform.localPosition = Vector3.zero;
        }

        public GameObject GetFish() {
            if (fishs.childCount == 0) {
                return null;
            } else {
                return fishs.GetChild(0).gameObject;
            }

        }

        public void UtilFish(Fish g) {
            g.transform.SetParent(fishs);
            g.transform.localPosition = Vector3.zero;
        }

    }
}
