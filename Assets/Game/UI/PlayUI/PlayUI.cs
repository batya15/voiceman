using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI {
    public class PlayUI : MonoBehaviour {

        [SerializeField]
        Text score;
        [SerializeField]
        Text best;
        [SerializeField]
        Text coins;

        void Awake() {
            Broadcaster.Subscribe(gameObject, "ChangedScore", "ChangedBestScore", "ChangedCoins");
            ChangedScore();
            ChangedBestScore();
            ChangedCoins();
        }
                                 
        void ChangedScore() {
            score.text = "Score: " + Voiceman.GameState.distance;
        }

        void ChangedBestScore() {
            best.text = "Best: " + Prefs.UserPrefs.best;
        }

        void ChangedCoins() {
            coins.text = "Coins: " + Prefs.UserPrefs.coins;
        }
    }

}
